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
                string rootPath = @"D:\Documents\Books";

                var fsvisitor = new FileSystemVisitor(rootPath, (info) => true);

                fsvisitor.Start += (s, e) => Console.WriteLine("Start:");

                fsvisitor.Finish += (s, e) => Console.WriteLine("Finish:");

                fsvisitor.DirectoryFound += (sender, e) =>
                    Console.WriteLine($"Directory found: {e.FoundItem.Name}");

                fsvisitor.FileFound += (sender, e) =>
                    Console.WriteLine($"File found: {e.FoundItem.Name}");

                // Find a directory according to filter and continue/stop the search.                
                fsvisitor.FilteredDirectoryFound += (sender, e) =>
                {
                    if (e.FoundItem.Name == "C#Books")
                    {
                        Console.WriteLine($"Filtered directory found: {e.FoundItem.Name}");
                        e.Option = SearchType.Continue;
                    }
                };

                // Find a file according to filter and continue/stop the search.
                fsvisitor.FilteredFileFound += (sender, e) =>
                {
                    if (e.FoundItem.Name == "Design_Patterns.txt")
                    {
                        Console.WriteLine($"Filtered file found: {e.FoundItem.Name}");
                        e.Option = SearchType.Stop;
                    }
                };

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
