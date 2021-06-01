using System;

namespace KataTasks
{
    public class OddEvenKata
    {
        public string PrintNumbers(int from, int to)
        {
            if ((@from <= 0 || to <= 0) || (@from >= to))
                throw new ArgumentException("Value does not fall within the expected range.");

            var result = string.Empty;
            var newNumber = string.Empty;

            for (int number = from; number <= to; number++)
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
            return number >= 2 && number % 2 == 0;
        }

        private static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        private static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (IsEven(number)) return false;

            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
