using GreetingStandardLibrary;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Task 1                     

            //if (args.Length == 0 || args[0].Any(char.IsDigit))
            //{                
            //    Console.WriteLine("Incorrect input");
            //}
            //else 
            //{
            //    Console.WriteLine($"Hello, {args[0]}!");
            //}
            #endregion

            #region Task 2

            string time = DateTime.Now.ToString("HH:mm:ss");
                     
            Console.WriteLine(UserInput.GreetUser(time, args, 0));
            #endregion
        }
    }
}
