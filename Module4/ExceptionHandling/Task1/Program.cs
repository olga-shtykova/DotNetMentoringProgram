using System;
using System.Text.RegularExpressions;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Type a string:");

                string inputString = Console.ReadLine();

                try
                {
                    Console.WriteLine(inputString[0]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("String is empty. Please try again.");
                }

            } while (true);
        }
    }
}