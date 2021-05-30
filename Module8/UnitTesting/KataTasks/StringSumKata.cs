using System;
using System.Numerics;

namespace KataTasks
{
    public class StringSumKata
    {
        public string Sum(string str1, string str2)
        {
            var naturalNum1 = CheckIfStringIsEmpty(str1);
            var naturalNum2 = CheckIfStringIsEmpty(str2);

            var result = AddNumbers(naturalNum1, naturalNum2);

            return result.ToString();
        }

        private static string CheckIfStringIsEmpty(string str)
        {
            return string.IsNullOrEmpty(str) ? "0" : str;
        }

        private static BigInteger AddNumbers(string str1, string str2)
        {
            try
            {
                var result = BigInteger.Parse(str1) + BigInteger.Parse(str2);

                return result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
