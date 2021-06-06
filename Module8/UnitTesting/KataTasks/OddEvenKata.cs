using System;

namespace KataTasks
{
    public class OddEvenKata
    {
        public static string PrintNumbers(int from, int to)
        {
            if (from <= 0 || to <= 0 || from >= to)
                throw new ArgumentException("Value does not fall within the expected range.");

            return CheckOddEvenPrimeOfNumbersInRange(from, to);
        }

        private static string CheckOddEvenPrimeOfNumbersInRange(int from, int to)
        {
            var result = string.Empty;

            for (int number = from; number <= to; number++)
            {
                var newNumber = CheckOddEvenPrimeOfaSingleNumber(number);
                result = string.Concat(result, " ", newNumber);
            }

            return result.Trim();
        }

        private static string CheckOddEvenPrimeOfaSingleNumber(int number)
        {
            var result = string.Empty;

            if (IsPrime(number))
            {
                result = Convert.ToString(number);
            }
            else if (IsEven(number))
            {
                result = "Even";
            }
            else if (IsOdd(number))
            {
                result = "Odd";
            }

            return result;
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
