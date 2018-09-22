using System;
using System.Collections.Generic;
using GoogleMini.Util;

namespace GoogleMini.FolderManagement
{
    public class TextFileEventCallbackArgs
    {        
        public int FileId { get; set; }
        public string FilePath { get; set; }
        public Action OnCompleted { get; set; }
    }

    public class TextFileBatchedEventCallbackArgs
    {
        public IList<int> FileIds { get; set; }
        public Action OnCompleted { get; set; }
    }
}