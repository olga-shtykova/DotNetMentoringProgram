using System;

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

        private static int AddNumbers(string str1, string str2)
        {
            return int.Parse(str1) + int.Parse(str2);
        }
    }
}
