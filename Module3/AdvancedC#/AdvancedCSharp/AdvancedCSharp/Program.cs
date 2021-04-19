using System;

namespace AdvancedCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"D:\Documents\C#books";

            FileSystemVisitor fsvisitor = new FileSystemVisitor(rootPath);

            fsvisitor.Start += () => Console.WriteLine("Start:");

            fsvisitor.Finish += () => Console.WriteLine("Finish:");

            fsvisitor.DirectoryFound += (sender, e) =>
               Console.WriteLine($"Directory found: {e.FoundItem.Name}");

            fsvisitor.FileFound += (sender, e) =>
                Console.WriteLine($"\tFile found: {e.FoundItem.Name}");

            fsvisitor.FilteredDirectoryFound += (sender, e) =>
                Console.WriteLine($"Filtered directory found: {e.FoundItem.Name}");

            fsvisitor.FilteredFileFound += (sender, e) =>
                Console.WriteLine($"\tFiltered file found: {e.FoundItem.Name}");

            foreach (var fileSysInfo in fsvisitor.GetFilesInDirectories())
            {
                Console.WriteLine(fileSysInfo);
            }

            Console.ReadKey();
        }
    }
}
