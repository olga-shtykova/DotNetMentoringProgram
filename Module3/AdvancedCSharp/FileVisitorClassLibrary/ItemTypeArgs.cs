using System;

namespace FileVisitorClassLibrary
{
    public class ItemTypeArgs<FileSystemInfo> : EventArgs 
    {
        public FileSystemInfo FoundItem { get; set; }
        public SearchType Option { get; set; }       
    }
}
