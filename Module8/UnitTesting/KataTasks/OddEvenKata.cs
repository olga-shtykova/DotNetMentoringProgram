using System;

namespace KataTasks
{
    public class OddEvenKata
    {
        private const int From = 1;
        private const int To = 100;

        public string PrintNumbers()
        {
            var result = string.Empty;
            var newNumber = string.Empty;

            for (int number = From; number <= To; number++)
            {
                if (IsPrime(number))
                {
                    newNumber = Convert.ToString(number);
                }
                else if (IsEven(number))
                {
                    newNumber = "Even";
                }
                else if (IsOdd(number))
                {
                    newNumber = "Odd";
                }
                
                result = string.Concat(result, " ", newNumber);
            }

            return result.Trim();
        }
        
        private static bool IsEven(int number)
        {
            if (number >= 2 && number % 2 == 0)
                return true;
            return false;
        }

        private static bool IsOdd(int number)
        {
            if (number % 2 != 0)
                return true;
            return false;
        }

        private static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (IsEven(number)) return false;

            for (int i = 2; i <= number / 2; i++)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
