using AdvancedCSharp;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystemVisitorTest
{
    public class Tests
    {        
        private Mock<FileSystemInfo> _fileSystemInfoMock;
        private FileSystemVisitor _fsVisitor;
        private readonly FileInfo _file1;        //= "test1.txt";
        private readonly DirectoryInfo _file2;    //= "test2.txt";

        
        [SetUp]
        public void Setup()
        {
            _fsVisitor = new FileSystemVisitor(@"D:\Documents\C#books");

            _fileSystemInfoMock = new Mock<FileSystemInfo>();
            List<FileSystemInfo> items = new List<FileSystemInfo> { _fileSystemInfoMock.Object }; // IEnumerable<FileSystemInfo>


            Mock.Get(_fsVisitor)
                .Setup(x => x.GetFilesInDirectories())
                .Returns((List<FileSystemInfo> x) =>
                new List<FileSystemInfo>
                {
                    _file1,
                    _file2
                });
        }

        [Test]
        public void Test1()
        {

            var files = _fsVisitor.GetFilesInDirectories();

            Assert.IsNotNull(files);
            Assert.IsTrue(files.Contains(_file1));
        }
    }
}