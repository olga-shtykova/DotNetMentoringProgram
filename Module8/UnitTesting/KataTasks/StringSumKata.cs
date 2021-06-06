using System;
using System.Numerics;

namespace KataTasks
{
    public class StringSumKata
    {
        public static string Sum(string str1, string str2)
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
                var num1 = IsPrime(BigInteger.Parse(str1));
                var num2 = IsPrime(BigInteger.Parse(str2));

                var result = num1 + num2;
                return result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static BigInteger IsPrime(BigInteger number)
        {
            if (number < 2) return 0;
            if (number >= 2 && number % 2 == 0) return 0;

            for (BigInteger i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                    return 0;
            }

            return number;
        }
    }
}
