using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GoogleMini.DataStore;
using GoogleMini.Util;

namespace GoogleMini.FolderManagement
{
    public class FolderManager : IDisposable
    {
        private readonly FileDatabase fileDatabase;
        private List<Folder> memoryCacheOfWatchedFolders;
        private ConcurrentDictionary<string, FileSystemWatcher> fileWatchers;

        public delegate void TextFileEventCallback(TextFileEventCallbackArgs args);
        public delegate void TextFileBatchedEventCallback(TextFileBatchedEventCallbackArgs args);

        public TextFileEventCallback TextFileCreated, TextFileRemoved, TextFileChanged;
        public TextFileBatchedEventCallback MultipleTextFilesDeleted;        

        public FolderManager(string databaseDirectory, IncrementalIdentityStore identityStore)
        {
            fileDatabase = new FileDatabase(databaseDirectory, identityStore);
            fileWatchers = new ConcurrentDictionary<string, FileSystemWatcher>(StringComparer.OrdinalIgnoreCase);
        }

        public void StartWatching()
        {
            var watchedFolders = fileDatabase.GetAllWatchedFolders();
            foreach (var folder in watchedFolders.Where(f => Directory.Exists(f.Path)))
            {
                var watcher = new FileSystemWatcher
                {
                    Path = folder.Path,
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
                    Filter = "*.txt"
                };

                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);

                if (fileWatchers.TryAdd(folder.Path, watcher))
                {
                    watcher.EnableRaisingEvents = true;
                }
            }
            memoryCacheOfWatchedFolders = watchedFolders;
        }

        public Dictionary<int, string> GetFilePathsFromIds(int[] Ids)
        {
            return fileDatabase.GetFilesPathsFromIds(Ids);
        }

        public List<Folder> GetWatchedFolders()
        {
            return memoryCacheOfWatchedFolders;
        }

        public void Watch(string folderPath)
        {
            folderPath = folderPath.Trim();
            if (fileWatchers.ContainsKey(folderPath))
                return;

            var folder = new Folder(folderPath, DateTime.UtcNow);
            memoryCacheOfWatchedFolders.Add(folder);
            fileDatabase.InsertWatchedFolder(folder);

            var watcher = new FileSystemWatcher
            {
                Path = folder.Path,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
                Filter = "*.txt"
            };

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            if (fileWatchers.TryAdd(folderPath, watcher))
            {
                watcher.EnableRaisingEvents = true;
            }

            foreach (var filePath in Directory.EnumerateFiles(folderPath))
            {
                var fileId = fileDatabase.InsertFileInfo(filePath);
                if (fileId < 0)
                    break;
                TextFileCreated?.Invoke(new TextFileEventCallbackArgs { FileId = fileId, FilePath = filePath });
            }
        }

        public void Unwatch(string folderPath)
        {
            folderPath = folderPath.Trim();
            if (fileWatchers.TryRemove(folderPath, out var watcher))
            {
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
            }

            memoryCacheOfWatchedFolders.RemoveAll(f => f.Path.Equals(folderPath, StringComparison.OrdinalIgnoreCase));

            var fileIds = fileDatabase.GetFilesIdsInFolder(folderPath);
            MultipleTextFilesDeleted?.Invoke(new TextFileBatchedEventCallbackArgs
            {
                FileIds = fileIds,
                OnCompleted = () =>
                {
                    foreach (var fileId in fileIds)
                    {
                        fileDatabase.DeleteFileInfo(fileId);
                    }
                    fileDatabase.RemoveWatchedFolder(folderPath);
                }
            });
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            fileDatabase.UpdateFileInfo(e.OldFullPath, e.FullPath);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            var fileId = fileDatabase.InsertFileInfo(e.FullPath);
            if (fileId <= 0)
                return;
            TextFileCreated?.Invoke(new TextFileEventCallbackArgs
            {
                FileId = fileId,
                FilePath = e.FullPath                
            });
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            var fileId = fileDatabase.GetFileId(e.FullPath);
            if (fileId <= 0)
                return;
            TextFileRemoved?.Invoke(new TextFileEventCallbackArgs
            {
                FileId = fileId,
                FilePath = e.FullPath,
                OnCompleted = () =>
                {
                    fileDatabase.DeleteFileInfo(fileId);
                }
            });
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            var fileId = fileDatabase.GetFileId(e.FullPath);
            if (fileId <= 0)
                return;
            TextFileChanged?.Invoke(new TextFileEventCallbackArgs
            {
                FileId = fileId,
                FilePath = e.FullPath
            });
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls       

        public void Dispose()
        {
            if (!disposedValue)
            {
                foreach (var item in fileWatchers)
                {
                    try
                    {
                        item.Value.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }
                fileDatabase?.Dispose();
                disposedValue = true;
            }
        }
        #endregion
    }
}
