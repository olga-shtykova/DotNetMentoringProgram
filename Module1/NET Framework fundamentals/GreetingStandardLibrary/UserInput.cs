using System;
using System.Linq;

namespace GreetingStandardLibrary
{
    public class UserInput
    {
        public static string GreetUser(string time, string[] args, int index)
        {
            if (args.Length == 0 || args[index].Any(char.IsDigit))
            {
                return "Incorrect input";
            }

            return $"{time} Hello, {args[index]}!";
        }
    }
}
