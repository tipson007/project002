using System;
using System.Linq;
using System.Collections.Generic;
using CSharpTest.Net.Collections;
using System.IO;
using CSharpTest.Net.Serialization;
using GoogleMini.DataStore;

namespace GoogleMini.FolderManagement
{
    public class FileDatabase : IDisposable
    {
        private const string Key_FileId = "FileDb@nextileId";
        private readonly string databaseDirectory;
        private readonly object insertLock;
        private readonly IncrementalIdentityStore identityStore;
        private bool rejectFileInsertion;
        private int nextFileId;
        private BPlusTree<string, int> filePathToIdMap;
        private BPlusTree<int, string> idToFilePathMap;
        private BPlusTree<string, Folder> watchedFoldersMap;


        public FileDatabase(string databaseDirectory, IncrementalIdentityStore identityStore)
        {
            this.databaseDirectory = databaseDirectory ?? throw new ArgumentNullException(nameof(databaseDirectory));
            this.identityStore = identityStore ?? throw new ArgumentNullException(nameof(identityStore));
            insertLock = new object();
            Init();
        }

        private void Init()
        {
            nextFileId = identityStore.GetNext(Key_FileId);
            rejectFileInsertion = (nextFileId == int.MaxValue);

            filePathToIdMap = new BPlusTree<string, int>(
                new BPlusTree<string, int>.OptionsV2(PrimitiveSerializer.String, VariantNumberSerializer.Int32)
                {
                    CreateFile = CreatePolicy.IfNeeded,
                    KeyComparer = StringComparer.OrdinalIgnoreCase,
                    FileName = Path.Combine(databaseDirectory, "filePathToIdMap.b+tree")
                }.CalcBTreeOrder(500, 4)
            );

            idToFilePathMap = new BPlusTree<int, string>(
                new BPlusTree<int, string>.OptionsV2(VariantNumberSerializer.Int32, PrimitiveSerializer.String)
                {
                    CreateFile = CreatePolicy.IfNeeded,
                    FileName = Path.Combine(databaseDirectory, "idToFilePathMap.b+tree")
                }.CalcBTreeOrder(4, 500)
            );

            watchedFoldersMap = new BPlusTree<string, Folder>(
                new BPlusTree<string, Folder>.OptionsV2(PrimitiveSerializer.String, FolderSerializer.Instance)
                {
                    CreateFile = CreatePolicy.IfNeeded,
                    KeyComparer = StringComparer.OrdinalIgnoreCase,
                    FileName = Path.Combine(databaseDirectory, "watchedFolders.b+tree")
                }.CalcBTreeOrder(500, 500)
            );
        }

        internal List<int> GetFilesIdsInFolder(string folderPath)
        {
            folderPath = folderPath.Trim();
            var fileIds = new List<int>();
            foreach (var kvPair in filePathToIdMap.EnumerateFrom(folderPath))
            {
                var filePathParentDir = Path.GetDirectoryName(kvPair.Key);
                if (filePathParentDir.Equals(folderPath, StringComparison.OrdinalIgnoreCase))
                    fileIds.Add(kvPair.Value);
                else if (!filePathParentDir.StartsWith(folderPath))
                    break;
            }
            return fileIds;
        }

        internal Dictionary<int, string> GetFilesPathsFromIds(int[] fileIds)
        {
            return fileIds.Distinct().OrderBy(v => v).ToDictionary(
                id => id, id => { idToFilePathMap.TryGetValue(id, out var path); return path; }
            );
        }

        internal List<Folder> GetAllWatchedFolders()
        {
            if(watchedFoldersMap.Any())
                return watchedFoldersMap.Select(kv=>kv.Value).ToList();
            return new List<Folder>();
        }

        internal int GetFileId(string fullPath)
        {
            fullPath = fullPath.Trim();
            filePathToIdMap.TryGetValue(fullPath, out var fileId);
            return fileId;
        }

        internal int InsertFileInfo(string fullPath)
        {
            if (rejectFileInsertion)
                return -1;

            fullPath = fullPath.Trim();
            lock (insertLock)
            {
                var fileId = nextFileId;
                idToFilePathMap[fileId] = fullPath;
                filePathToIdMap[fullPath] = fileId;
                identityStore.SetNext(Key_FileId, ++nextFileId);
                return fileId;
            }
        }

        internal void UpdateFileInfo(string oldFullPath, string newFullPath)
        {
            oldFullPath = oldFullPath.Trim();
            newFullPath = newFullPath.Trim();

            if (filePathToIdMap.TryRemove(oldFullPath, out var fileId))
            {               
                filePathToIdMap[newFullPath] = fileId;
                idToFilePathMap[fileId] = newFullPath;
            }
        }

        internal void DeleteFileInfo(int fileId)
        {
            if (idToFilePathMap.TryRemove(fileId, out var filePath))
            {
                filePathToIdMap.TryRemove(filePath, out var _);
            }
        }

        internal void RemoveWatchedFolder(string folderPath)
        {
            var key = folderPath.Trim();
            watchedFoldersMap.TryRemove(key, out var _);
        }

        internal void InsertWatchedFolder(Folder folder)
        {
            var key = folder.Path.Trim();
            watchedFoldersMap[key] = folder;
        }

        public void Dispose()
        {
            var bPlusTrees = new IDisposable[] { idToFilePathMap, filePathToIdMap, watchedFoldersMap };
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
