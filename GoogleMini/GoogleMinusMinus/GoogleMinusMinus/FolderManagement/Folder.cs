using System;
using System.IO;

namespace GoogleMini.FolderManagement
{
    public class Folder
    {
        public string Path { get; }
        public string Name { get; }
        public DateTime DateAdded { get; }

        public Folder(string path, DateTime dateAdded)
        {
            Path = path;
            Name = new DirectoryInfo(path).Name;
            DateAdded = dateAdded;
        }
    }
}
