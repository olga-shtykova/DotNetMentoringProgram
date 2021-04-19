using System;
using System.Collections.Generic;
using System.IO;

namespace AdvancedCSharp
{
    public delegate void EventDelegate();

    public delegate void ElementFoundDelegate(object sender, AnswerEventArgs<FileSystemInfo> e);

    public class FileSystemVisitor
    {
        private readonly DirectoryInfo _startDirectory;

        private List<FileSystemInfo> _files;

        private readonly Func<FileSystemInfo, bool> _filter;


        public FileSystemVisitor(string path,
            Func<FileSystemInfo, bool> filter = null) : this(new DirectoryInfo(path), filter)
        { }


        public FileSystemVisitor(DirectoryInfo startDirectory, Func<FileSystemInfo, bool> filter = null)
        {
            _files = new List<FileSystemInfo>();
            _startDirectory = startDirectory;
            _filter = filter;
        }

        public bool StopSearchFlag { get; set; }
        public bool SkipElementFlag { get; set; }

        public event EventDelegate Start;
        public event EventDelegate Finish;
        public event ElementFoundDelegate FileFound;
        public event ElementFoundDelegate DirectoryFound;
        public event ElementFoundDelegate FilteredFileFound;
        public event ElementFoundDelegate FilteredDirectoryFound;


        public IEnumerable<FileSystemInfo> GetFilesInDirectories()
        {
            Start?.Invoke();

            foreach (var fileSystemInfo in IterateThroughDirectories(_startDirectory))
            {
                yield return fileSystemInfo;
            }

            Finish?.Invoke();
        }

        private IEnumerable<FileSystemInfo> IterateThroughDirectories(DirectoryInfo directory)
        {
            AnswerEventArgs<FileSystemInfo> e = new AnswerEventArgs<FileSystemInfo>();

            foreach (var fileSystemInfo in directory.EnumerateFileSystemInfos())
            {
                e.FoundItem = fileSystemInfo;

                if (StopSearchFlag) break;

                if (fileSystemInfo is FileInfo file)
                {
                    if (_filter == null)
                        FileFound?.Invoke(this, e);
                    else
                        FilteredFileFound?.Invoke(this, e);
                }

                if (fileSystemInfo is DirectoryInfo direct)
                {
                    if (_filter == null)
                        DirectoryFound?.Invoke(this, e);
                    else
                        FilteredDirectoryFound?.Invoke(this, e);

                    foreach (var item in IterateThroughDirectories(direct))
                    {
                        yield return item;
                    }
                }

                if ((!SkipElementFlag) || (!SkipElementFlag && _filter(fileSystemInfo)))
                    _files.Add(fileSystemInfo);
                SkipElementFlag = false;
            }
        }
    }
}
