using FileVisitorClassLibrary;
using System;
using System.IO;
using System.Linq;

namespace AdvancedCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string rootPath = @"D:\Documents\C#books";

                var fsvisitor = new FileSystemVisitor(rootPath, (info) => true);

                fsvisitor.Start += (s, e) => Console.WriteLine("Start:");

                fsvisitor.Finish += (s, e) => Console.WriteLine("Finish:");

                fsvisitor.DirectoryFound += (sender, e) =>
                    Console.WriteLine($"Directory found: {e.FoundItem.Name}");

                fsvisitor.FileFound += (sender, e) =>
                    Console.WriteLine($"\tFile found: {e.FoundItem.Name}");               

                fsvisitor.FilteredDirectoryFound += (sender, e) =>
                {
                    Console.WriteLine($"Filtered directory found: {e.FoundItem.Name}");

                    if (e.FoundItem.Name == "Patterns")
                    {
                        e.Option = SearchType.Stop;
                    }
                };

                fsvisitor.FilteredFileFound += (sender, e) =>
                    Console.WriteLine($"\tFiltered file found: {e.FoundItem.Name}");        

                var fileSystemInfo = fsvisitor.GetFilesInDirectories().ToArray();
            }

            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            Console.ReadKey();
        }
    }
}
