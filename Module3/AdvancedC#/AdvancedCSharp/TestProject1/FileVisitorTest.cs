using AdvancedCSharp;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace TestProject
{
    public class FileVisitorTest
    {      
        private const string folderName = "Directory";
        private FileSystemVisitor _fsvisitor;
        private Func<FileSystemInfo, bool> _filter;

        private string GetTestFolderPath()
        {
            var dir = Directory.GetCurrentDirectory();

            var parent = Directory.GetParent(dir).Parent.Parent.FullName;

            return Path.Combine(parent, folderName);
        }

        public FileVisitorTest()
        {
            _filter = filter => filter.Name.Contains("txt");

            _fsvisitor = new FileSystemVisitor(GetTestFolderPath(), _filter);

            //_e = new AnswerEventArgs<FileSystemInfo>();
        }

        [Fact]
        public void StartEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 1;

            _fsvisitor.Start += () => eventInvokeCounter++;

            var result = _fsvisitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void FinishEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 1;

            _fsvisitor.Finish += () => eventInvokeCounter++;

            var result = _fsvisitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void DirectoryFoundEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 1;

            _fsvisitor = new FileSystemVisitor(GetTestFolderPath(), null);

            _fsvisitor.DirectoryFound += (_fsvisitor, e) => eventInvokeCounter++;

            var result = _fsvisitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void FilteredDirectoryFoundEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 1;

            _fsvisitor.FilteredDirectoryFound += (_fsvisitor, e) => eventInvokeCounter++;

            var result = _fsvisitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void FileFoundEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 5;

            _fsvisitor = new FileSystemVisitor(GetTestFolderPath(), null);

            _fsvisitor.FileFound += (_fsvisitor, e) => eventInvokeCounter++;

            var result = _fsvisitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void FilteredFileFoundEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 5;

            _fsvisitor.FilteredFileFound += (_fsvisitor, e) => eventInvokeCounter++;

            var result = _fsvisitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }
    }
}
