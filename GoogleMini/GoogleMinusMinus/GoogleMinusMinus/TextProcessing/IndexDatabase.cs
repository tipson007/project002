using System;
using System.Linq;
using System.Collections.Generic;
using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;
using System.IO;
using GoogleMini.Util;
using GoogleMini.DataStore;
using System.Diagnostics;

namespace GoogleMini.TextProcessing
{
    public class IndexDatabase : IDisposable
    {
        private const int MaxBatchSize = 1000;
        private const string Key_NextWordId = "IndexDb@nextWordId", Key_NextOccurrenceId = "IndexDb@nextOccurrenceId";
        private readonly object insertLock;
        private readonly string databaseDirectory;
        private readonly IncrementalIdentityStore identityStore;
        private bool rejectInsertion;
        private int nextWordId, nextOccurrenceId;
        private BPlusTree<string, int> wordToIdMap;
        private BPlusTree<int, string> idToWordMap;
        private BPlusTree<ulong, WordOccurrence> wordCompoundIdToOccurrenceMap;
        private BPlusTree<ulong, List<ulong>> fileCompoundIdToWordCompoundIdsMap;


        public IndexDatabase(string databaseDirectory, IncrementalIdentityStore identityStore)
        {
            this.databaseDirectory = databaseDirectory ?? throw new ArgumentNullException(nameof(databaseDirectory));
            this.identityStore = identityStore ?? throw new ArgumentNullException(nameof(identityStore));
            insertLock = new object();
            Init();
        }

        private void Init()
        {
            nextWordId = identityStore.GetNext(Key_NextWordId);
            nextOccurrenceId = identityStore.GetNext(Key_NextOccurrenceId);
            rejectInsertion = (nextWordId == int.MaxValue || nextOccurrenceId == int.MaxValue);

            wordToIdMap = new BPlusTree<string, int>(
                new BPlusTree<string, int>.OptionsV2(PrimitiveSerializer.String, VariantNumberSerializer.Int32)
                {
                    CreateFile = CreatePolicy.IfNeeded,
                    KeyComparer = StringComparer.OrdinalIgnoreCase,
                    FileName = Path.Combine(databaseDirectory, "wordToIdMap.b+tree")
                }.CalcBTreeOrder(100, 4)
            );

            idToWordMap = new BPlusTree<int, string>(
                new BPlusTree<int, string>.OptionsV2(VariantNumberSerializer.Int32, PrimitiveSerializer.String)
                {
                    CreateFile = CreatePolicy.IfNeeded,
                    FileName = Path.Combine(databaseDirectory, "idToWordMap.b+tree")
                }.CalcBTreeOrder(4, 100)
            );

            fileCompoundIdToWordCompoundIdsMap = new BPlusTree<ulong, List<ulong>>(
                new BPlusTree<ulong, List<ulong>>.OptionsV2(
                VariantNumberSerializer.UInt64, new ListSerializer<ulong>(VariantNumberSerializer.UInt64))
                {
                    CreateFile = CreatePolicy.IfNeeded,
                    FileName = Path.Combine(databaseDirectory, "fileCompoundIdToWordCompoundIdsMap.b+tree")
                }.CalcBTreeOrder(8, 4 + 8 * MaxBatchSize)
            );

            wordCompoundIdToOccurrenceMap = new BPlusTree<ulong, WordOccurrence>(
                new BPlusTree<ulong, WordOccurrence>.OptionsV2(
                VariantNumberSerializer.UInt64, WordOccurrenceSerializer.Instance)
                {
                    CreateFile = CreatePolicy.IfNeeded,
                    FileName = Path.Combine(databaseDirectory, "wordCompoundIdToOccurrenceMap.b+tree")
                }.CalcBTreeOrder(8, 16)
            );
        }

        internal Statistics RecomputeStatistics()
        {
            var totalWordsIndexed = 0;
            var totalUniqueWordsIndexed = 0;
            var longestWordIndexed = string.Empty;
            var shortestWordIndexed = string.Empty;
            var mostFrequentWordIndexed = string.Empty;
            var leastFrequentWordIndexed = string.Empty;
            var mostFrequentWordCount = 0;
            var leastFrequentWordCount = int.MaxValue;

            var currentWordId = -1;
            var currentWord = string.Empty;
            var currentWordFrequency = 0;

            foreach (var compoundKey in wordCompoundIdToOccurrenceMap.Keys)
            {
                var wordId = CompoundId.Split(compoundKey).Item1;

                if (currentWordId != wordId)
                {
                    if (currentWordId != -1)
                    {
                        if (currentWordFrequency >= mostFrequentWordCount)
                        {
                            mostFrequentWordCount = currentWordFrequency;
                            mostFrequentWordIndexed = currentWord;
                        }
                        if (currentWordFrequency <= leastFrequentWordCount)
                        {
                            leastFrequentWordCount = currentWordFrequency;
                            leastFrequentWordIndexed = currentWord;
                        }
                    }

                    currentWordId = wordId;
                    currentWordFrequency = 0;
                    currentWord = idToWordMap[wordId];
                    totalUniqueWordsIndexed++;

                    if (currentWord.Length >= longestWordIndexed.Length)
                        longestWordIndexed = currentWord;
                    if (currentWord.Length <= shortestWordIndexed.Length || string.IsNullOrEmpty(shortestWordIndexed))
                        shortestWordIndexed = currentWord;
                }
                totalWordsIndexed++;
                currentWordFrequency++;
            }

            return new Statistics(totalWordsIndexed, totalUniqueWordsIndexed, longestWordIndexed, shortestWordIndexed, mostFrequentWordIndexed, leastFrequentWordIndexed);
        }

        internal void Insert(int fileId, IEnumerable<(string, WordOccurrence)> word_WordOccurrencePairs)
        {
            if (rejectInsertion)
                return;
            lock (insertLock)
            {
                var batchNumber = 0;
                foreach (var batch in word_WordOccurrencePairs.Batch(MaxBatchSize))
                {
                    var sw = Stopwatch.StartNew();
                    var compoundKeys = new List<ulong>();
                    foreach (var group in batch.GroupBy(t => t.Item1))
                    {
                        var word = group.Key.Trim();
                        var wordId = wordToIdMap.GetOrAdd(word, nextWordId);
                        var newlyAdded = (wordId == nextWordId);
                        if (newlyAdded)
                        {
                            identityStore.SetNext(Key_NextWordId, ++nextWordId);
                            idToWordMap[wordId] = word;
                        }

                        foreach (var occurrence in group.Select(t => t.Item2))
                        {
                            var uniqueId = CompoundId.Combine(wordId, nextOccurrenceId++);
                            compoundKeys.Add(uniqueId);
                            wordCompoundIdToOccurrenceMap[uniqueId] = occurrence;
                        }

                        identityStore.SetNext(Key_NextOccurrenceId, nextOccurrenceId);
                    }
                    fileCompoundIdToWordCompoundIdsMap[CompoundId.Combine(fileId, batchNumber++)] = compoundKeys;
                    sw.Stop();
                    Debug.WriteLine($"AddFileContentRequest took {sw.Elapsed.ToString(@"m\:ss")}");
                }
            }
        }

        internal IEnumerable<WordOccurrence> FindWord(string firstWord)
        {
            if (wordToIdMap.TryGetValue(firstWord, out var wordId))
            {
                var wordCompoundId = CompoundId.Combine(wordId, 0);
                foreach (var kvPair in wordCompoundIdToOccurrenceMap.EnumerateFrom(wordCompoundId))
                {
                    if (CompoundId.Split(kvPair.Key).Item1 == wordId)
                        yield return kvPair.Value;
                    else
                        yield break;
                }
            }
        }

        internal void DeleteByFileId(int fileId)
        {
            var compoundFileIdsToDelete = new List<ulong>();
            var fileCompoundId = CompoundId.Combine(fileId, 0);
            foreach (var kvPair in fileCompoundIdToWordCompoundIdsMap.EnumerateFrom(fileCompoundId))
            {
                if (CompoundId.Split(kvPair.Key).Item1 == fileId)
                {
                    compoundFileIdsToDelete.Add(kvPair.Key);
                    foreach (var wordCompoundId in kvPair.Value)
                    {
                        wordCompoundIdToOccurrenceMap.TryRemove(wordCompoundId, out var _);
                    }
                }
                else
                    break;
            }
            foreach (var compoundFileId in compoundFileIdsToDelete)
            {
                fileCompoundIdToWordCompoundIdsMap.TryRemove(compoundFileId, out var _);
            }
        }

        public void Dispose()
        {
            var bPlusTrees = new IDisposable[] {
                fileCompoundIdToWordCompoundIdsMap ,
                wordCompoundIdToOccurrenceMap,
                idToWordMap,
                wordToIdMap
            };
            foreach (var tree in bPlusTrees)
            {
                try
                {
                    tree?.Dispose();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
