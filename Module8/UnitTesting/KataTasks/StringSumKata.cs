using System;

namespace KataTasks
{
    public class StringSumKata
    {
        public string Sum(string str1, string str2)
        {
            var naturalNum1 = CheckIfStringIsEmpty(str1);
            var naturalNum2 = CheckIfStringIsEmpty(str2);

            int num1Int, num2Int;

            int.TryParse(naturalNum1, out num1Int);
            int.TryParse(naturalNum2, out num2Int);

            return (num1Int + num2Int).ToString();
        }

        private string CheckIfStringIsEmpty(string str)
        {
            return string.IsNullOrEmpty(str) ? "0" : str;
        }
    }
}
