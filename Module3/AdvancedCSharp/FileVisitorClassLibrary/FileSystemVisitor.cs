using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace FileVisitorClassLibrary
{
    public class FileSystemVisitor
    {
        private readonly DirectoryInfo _startDirectory;
        private readonly Func<FileSystemInfo, bool> _filter;
       
        public FileSystemVisitor(string path,
            Func<FileSystemInfo, bool> filter = null, IFileSystem filesystem = null)
        {
            _startDirectory = new DirectoryInfo(path);
            _filter = filter;
        }

        public event EventHandler Start;
        public event EventHandler Finish;
        public event EventHandler<ItemTypeArgs<FileSystemInfo>> FileFound;
        public event EventHandler<ItemTypeArgs<FileSystemInfo>> FilteredFileFound;
        public event EventHandler<ItemTypeArgs<FileSystemInfo>> DirectoryFound;
        public event EventHandler<ItemTypeArgs<FileSystemInfo>> FilteredDirectoryFound;


        public IEnumerable<FileSystemInfo> GetFilesInDirectories()
        {
            var startDirectory = _startDirectory;

            if (!Directory.Exists(startDirectory.ToString()))
            {
                throw new DirectoryNotFoundException($"Directory was not found.");
            }            

            OnEvent(Start);

            foreach (var fileSystemInfo in IterateThroughDirectories(_startDirectory, 
                SearchChoice.Continue))
            {
                yield return fileSystemInfo;
            }

            OnEvent(Finish);
        }

        private IEnumerable<FileSystemInfo> IterateThroughDirectories(DirectoryInfo directoryInfo, 
            SearchChoice searchChoice)
        {    
            var e = new ItemTypeArgs<FileSystemInfo>();
            var itemsInDirectory = directoryInfo.EnumerateFileSystemInfos();           

            foreach (var fileSystemInfo in itemsInDirectory)
            {
                e.FoundItem = fileSystemInfo;

                if (searchChoice.Choice == SearchType.Stop) yield break;

                if (fileSystemInfo is DirectoryInfo dir)
                {
                    searchChoice.Choice = ProcessItem(dir, _filter, DirectoryFound,
                        FilteredDirectoryFound, OnEvent);

                    foreach (var item in IterateThroughDirectories(dir, searchChoice))
                    {
                        yield return item;
                    }
                    continue;
                }

                if (fileSystemInfo is FileInfo file)
                {
                    searchChoice.Choice = ProcessItem(file, _filter, FileFound,
                        FilteredFileFound, OnEvent);                    
                }

                yield return fileSystemInfo;
            }            
        }

        #region Private Methods
        private class SearchChoice
        {
            public SearchType Choice { get; set; }
            public static SearchChoice Continue
                => new SearchChoice { Choice = SearchType.Continue };
        }

        private void OnEvent<FileSystemInfo>(EventHandler<FileSystemInfo> someEvent, FileSystemInfo args)
        {
            someEvent?.Invoke(this, args);
        }

        private void OnEvent(EventHandler someEvent, EventArgs e = null)
        {
            someEvent?.Invoke(this, e);
        }

        private SearchType ProcessItem(FileSystemInfo item,
           Func<FileSystemInfo, bool> filter,
           EventHandler<ItemTypeArgs<FileSystemInfo>> ItemFound,
           EventHandler<ItemTypeArgs<FileSystemInfo>> FilteredItemFound,
           Action<EventHandler<ItemTypeArgs<FileSystemInfo>>, ItemTypeArgs<FileSystemInfo>> eHandler
           )
        {
            var eventArgs = new ItemTypeArgs<FileSystemInfo>
            {
                FoundItem = item,
                Option = SearchType.Continue
            };

            eHandler(ItemFound, eventArgs);

            if (eventArgs.Option != SearchType.Continue || filter == null)
            {
                return eventArgs.Option;
            }

            if (filter(item))
            {
                eventArgs = new ItemTypeArgs<FileSystemInfo>
                {
                    FoundItem = item,
                    Option = SearchType.Continue
                };

                eHandler(FilteredItemFound, eventArgs);
                return eventArgs.Option;
            }

            return SearchType.Skip;
        }

        #endregion
    }
}

