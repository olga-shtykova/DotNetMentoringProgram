using AdvancedCSharp;
using FileVisitorClassLibrary;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace TestProject
{
    public class FileVisitorTest
    {      
        private const string folderName = "Directory";
        private FileSystemVisitor _visitor;
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

            _visitor = new FileSystemVisitor(GetTestFolderPath(), _filter);
        }

        [Fact]
        public void StartEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 1;

            _visitor.Start += (s, e) => eventInvokeCounter++;

            var result = _visitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void FinishEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 1;

            _visitor.Start += (s, e) => eventInvokeCounter++;

            var result = _visitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void DirectoryFoundEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 2;

            _visitor = new FileSystemVisitor(GetTestFolderPath(), null);

            _visitor.DirectoryFound += (s, e) => eventInvokeCounter++;

            var result = _visitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void FilteredDirectoryFoundEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 2;

            _visitor.FilteredDirectoryFound += (s, e) => eventInvokeCounter++;

            var result = _visitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void FileFoundEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 4;

            _visitor = new FileSystemVisitor(GetTestFolderPath(), null);

            _visitor.FileFound += (s, e) => eventInvokeCounter++;

            var result = _visitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }

        [Fact]
        public void FilteredFileFoundEventTest()
        {
            var eventInvokeCounter = 0;
            var expectedValue = 4;

            _visitor.FilteredFileFound += (s, e) => eventInvokeCounter++;

            var result = _visitor.GetFilesInDirectories().ToArray();

            Assert.Equal(expectedValue, eventInvokeCounter);
        }
    }
}
