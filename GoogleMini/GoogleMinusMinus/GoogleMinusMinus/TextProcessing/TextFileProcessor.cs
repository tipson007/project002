using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleMini.DataStore;
using GoogleMini.Util;

namespace GoogleMini.TextProcessing
{
    public class TextFileProcessor : IDisposable
    {
        private class Request
        {
            internal long TimeStamp { get; set; }
            internal Action OnRequestCompleted { get; set; }
        }
        private class AddFileContentRequest : Request
        {
            internal int Retries { get; set; }
            internal int FileId { get; set; }
            internal string FilePath { get; set; }
        }
        private class UpdateFileContentRequest : Request
        {
            internal int Retries { get; set; }
            internal int FileId { get; set; }
            internal string FilePath { get; set; }
        }
        private class RemoveFileContentRequest : Request
        {
            internal int FileId { get; set; }
        }
        private class BatchedRemoveFileContentRequest : Request
        {
            internal IList<int> FileIds { get; set; }
        }
        private class RequestRegistrar
        {
            private enum RequestType { AddFileContent, RemoveFileContent }
            private Dictionary<(int, RequestType), long> handledRequests;
            private Queue<(long, int, RequestType)> ageQueue;

            internal RequestRegistrar()
            {
                handledRequests = new Dictionary<(int, RequestType), long>();
                ageQueue = new Queue<(long, int, RequestType)>();
            }

            private bool IsRequestRedundant(int fileId, RequestType requestType, long timeStampWhenSubmitted)
            {
                if (handledRequests.TryGetValue((fileId, requestType), out var timeStampWhenProcessed))
                {
                    return (timeStampWhenSubmitted <= timeStampWhenProcessed);
                }
                return false;
            }

            private void RequestProcessed(int fileId, RequestType requestType, long timeStampWhenSubmitted, long timeStampWhenProcessed)
            {
                handledRequests[(fileId, requestType)] = timeStampWhenProcessed;
                ageQueue.Enqueue((timeStampWhenProcessed, fileId, requestType));
                if (ageQueue.Count < 2)
                    return;
                var reqData = ageQueue.Peek();
                var oldestTimeStampWhenProcessed = reqData.Item1;
                if (timeStampWhenSubmitted > oldestTimeStampWhenProcessed)
                {
                    ageQueue.Dequeue();
                    handledRequests.Remove((reqData.Item2, reqData.Item3));
                }
            }

            internal bool IsRequestRedundant(AddFileContentRequest request)
            {
                return IsRequestRedundant(request.FileId, RequestType.AddFileContent, request.TimeStamp);
            }

            internal void RequestProcessed(AddFileContentRequest request, long timeStampWhenProcessed)
            {
                RequestProcessed(request.FileId, RequestType.AddFileContent, request.TimeStamp, timeStampWhenProcessed);
            }

            internal bool IsRequestRedundant(UpdateFileContentRequest request)
            {
                return IsRequestRedundant(request.FileId, RequestType.AddFileContent, request.TimeStamp);
            }

            internal void RequestProcessed(UpdateFileContentRequest request, long timeStampWhenProcessed)
            {
                RequestProcessed(request.FileId, RequestType.AddFileContent, request.TimeStamp, timeStampWhenProcessed);
            }

            internal bool IsRequestRedundant(RemoveFileContentRequest request)
            {
                return IsRequestRedundant(request.FileId, RequestType.RemoveFileContent, request.TimeStamp);
            }

            internal void RequestProcessed(RemoveFileContentRequest request, long timeStampWhenProcessed)
            {
                RequestProcessed(request.FileId, RequestType.RemoveFileContent, request.TimeStamp, timeStampWhenProcessed);
            }
        }

        private const long MinWaitingTime = 500;

        private Stopwatch internalClock;
        private Task processingTask;
        private IndexDatabase indexDatabase;
        private Lazy<HashSet<string>> lazyIgnoreSet;
        private BlockingCollection<Request> requestQueue;
        private CancellationTokenSource processingTaskCancellationTokenSource;

        /// <summary>
        /// Fired when the request queue is empty.
        /// </summary>
        public event EventHandler OnIdle;

        public TextFileProcessor(string databaseDirectory, IncrementalIdentityStore identityStore)
        {
            indexDatabase = new IndexDatabase(databaseDirectory, identityStore);
            lazyIgnoreSet = new Lazy<HashSet<string>>(() =>
            {
                try
                {
                    return new HashSet<string>(File.ReadAllLines(Path.Combine(databaseDirectory, "ignoreList.txt")).Select(s => s.ToLowerInvariant().Trim()));
                }
                catch (IOException)
                {
                    return new HashSet<string>();
                }
            }, false);
        }

        public Statistics RecomputeStatistics()
        {
            return indexDatabase.RecomputeStatistics();
        }

        public void TextFileCreated(int fileId, string filePath, Action onRequestCompleted = null, int numberOfRetries = 0)
        {
            requestQueue.Add(new AddFileContentRequest
            {
                FileId = fileId,
                FilePath = filePath,
                Retries = numberOfRetries,
                OnRequestCompleted = onRequestCompleted,
                TimeStamp = internalClock.ElapsedTicks
            });
        }

        public void TextFileChanged(int fileId, string filePath, Action onRequestCompleted = null, int numberOfRetries = 0)
        {
            requestQueue.Add(new UpdateFileContentRequest
            {
                FileId = fileId,
                FilePath = filePath,
                Retries = numberOfRetries,
                OnRequestCompleted = onRequestCompleted,
                TimeStamp = internalClock.ElapsedTicks
            });
        }

        public void TextFilesRemoved(IList<int> fileIds, Action onRequestCompleted = null)
        {
            if (fileIds.Count == 1)
            {
                requestQueue.Add(new RemoveFileContentRequest
                {
                    FileId = fileIds[0],
                    OnRequestCompleted = onRequestCompleted,
                    TimeStamp = internalClock.ElapsedTicks
                });
            }
            else
            {
                requestQueue.Add(new BatchedRemoveFileContentRequest
                {
                    FileIds = fileIds,
                    OnRequestCompleted = onRequestCompleted,
                    TimeStamp = internalClock.ElapsedTicks
                });
            }
        }

        public List<WordOccurrence> SearchIndex(string searchText)
        {
            var firstWord = searchText.Split().FirstOrDefault(s => !string.IsNullOrWhiteSpace(s));
            return indexDatabase.FindWord(firstWord).ToList();
        }

        public void StartRequestProcessingLoop()
        {
            requestQueue = new BlockingCollection<Request>(new ConcurrentQueue<Request>());
            processingTaskCancellationTokenSource = new CancellationTokenSource();
            var token = processingTaskCancellationTokenSource.Token;
            processingTask = Task.Run(() => ProcessRequests(token), token);
        }

        public void HaltRequestProcessingLoop()
        {
            if (processingTaskCancellationTokenSource?.IsCancellationRequested ?? true)
                return;
            try
            {
                processingTaskCancellationTokenSource?.Cancel();
                processingTask?.Wait();
            }
            catch (AggregateException errors)
            {
                errors.Handle(e => e is OperationCanceledException);
            }
            finally
            {
                processingTaskCancellationTokenSource?.Dispose();
                processingTask?.Dispose();
                requestQueue?.Dispose();
                requestQueue = null;
                processingTaskCancellationTokenSource = null;
            }
        }

        private void ProcessRequests(CancellationToken cancellationToken)
        {
            try
            {
                internalClock = new Stopwatch();
                internalClock.Start();
                var requestRegistrar = new RequestRegistrar();
                foreach (var request in requestQueue.GetConsumingEnumerable(cancellationToken))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var waitingTime = internalClock.ElapsedTicks - request.TimeStamp;
                    if (waitingTime < MinWaitingTime)
                        Thread.Sleep((int)(MinWaitingTime - waitingTime));
                    var processedTimestamp = internalClock.ElapsedTicks;
                    switch (request)
                    {
                        case AddFileContentRequest addReq when !requestRegistrar.IsRequestRedundant(addReq):
                            if (HandleAddFileContentRequest(addReq))
                            {
                                requestRegistrar.RequestProcessed(addReq, processedTimestamp);
                            }
                            break;
                        case UpdateFileContentRequest updReq when !requestRegistrar.IsRequestRedundant(updReq):
                            if (HandleUpdateFileContentRequest(updReq))
                            {
                                requestRegistrar.RequestProcessed(updReq, processedTimestamp);
                            }
                            break;
                        case RemoveFileContentRequest remReq when !requestRegistrar.IsRequestRedundant(remReq):
                            if (HandleRemoveFileContentRequest(remReq))
                            {
                                requestRegistrar.RequestProcessed(remReq, processedTimestamp);
                            }
                            break;
                        case BatchedRemoveFileContentRequest batchedRemReq:
                            HandleRemoveFileContentRequest(batchedRemReq);
                            foreach (var fileId in batchedRemReq.FileIds)
                            {
                                requestRegistrar.RequestProcessed(new RemoveFileContentRequest()
                                {
                                    FileId = fileId,
                                    TimeStamp = batchedRemReq.TimeStamp
                                }, processedTimestamp);
                            }
                            break;
                    }
                    if (requestQueue.Count == 0)
                    {
                        Task.Run(() => OnIdle?.Invoke(this, EventArgs.Empty));
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private IEnumerable<(string, WordOccurrence)> GetWordOccurrences(AddFileContentRequest request)
        {
            using (var wreader = new WordReader(request.FilePath))
            {
                foreach (var word in wreader.ReadWords())
                {
                    var wordText = word.Text.ToLowerInvariant().Trim();
                    if (lazyIgnoreSet.Value.Contains(wordText) || wordText.Length <= 1)
                        continue;
                    var wordOccurrence = new WordOccurrence
                    {
                        ColumnNumber = word.ColumnNumber,
                        FileId = request.FileId,
                        LineNumber = word.LineNumber,
                        CharIndex = word.LocationIndex
                    };
                    yield return (wordText, wordOccurrence);
                }
            }
        }

        private bool HandleAddFileContentRequest(AddFileContentRequest request)
        {
            try
            {                
                indexDatabase.Insert(request.FileId, GetWordOccurrences(request));
                request.OnRequestCompleted?.Invoke();                
                return true;
            }
            catch (IOException)
            {
                RetryAddFileContentRequest(request);
                return false;
            }
            catch (Exception) { return false; }
        }

        private void RetryAddFileContentRequest(AddFileContentRequest request)
        {
            var timeOut = (1 << request.Retries + 1) * MinWaitingTime;
            var timer = new Timer(a =>
            {
                var req = (AddFileContentRequest)a;
                TextFileCreated(req.FileId, req.FilePath, req.OnRequestCompleted, req.Retries + 1);
            }, request, timeOut, Timeout.Infinite);
        }

        private bool HandleUpdateFileContentRequest(UpdateFileContentRequest updReq)
        {
            if (HandleRemoveFileContentRequest(new RemoveFileContentRequest { FileId = updReq.FileId }))
            {
                return HandleAddFileContentRequest(new AddFileContentRequest { FileId = updReq.FileId, FilePath = updReq.FilePath, Retries = updReq.Retries });
            }
            else
            {
                RetryUpdateFileContentRequest(updReq);
                return false;
            }
        }

        private void RetryUpdateFileContentRequest(UpdateFileContentRequest request)
        {
            var timeOut = (1 << request.Retries + 1) * MinWaitingTime;
            var timer = new Timer(a =>
            {
                var req = (UpdateFileContentRequest)a;
                TextFileChanged(req.FileId, req.FilePath, req.OnRequestCompleted, req.Retries + 1);
            }, request, timeOut, Timeout.Infinite);
        }

        private bool HandleRemoveFileContentRequest(RemoveFileContentRequest request)
        {
            try
            {
                indexDatabase.DeleteByFileId(request.FileId);
                request.OnRequestCompleted?.Invoke();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool HandleRemoveFileContentRequest(BatchedRemoveFileContentRequest request)
        {
            try
            {
                foreach (var fileId in request.FileIds)
                {
                    indexDatabase.DeleteByFileId(fileId);
                }
                request.OnRequestCompleted?.Invoke();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls       

        public void Dispose()
        {
            if (!disposedValue)
            {
                HaltRequestProcessingLoop();
                indexDatabase?.Dispose();
                disposedValue = true;
            }
        }
        #endregion
    }
}
