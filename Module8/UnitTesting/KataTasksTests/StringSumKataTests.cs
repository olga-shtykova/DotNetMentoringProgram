using KataTasks;
using NUnit.Framework;

namespace KataTasksTests
{
    public class StringSumKataTests
    {
        private StringSumKata _stringSumKata;

        [SetUp]
        public void Setup()
        {
            _stringSumKata = new StringSumKata();
        }

        [TestCase(null, "", "0")]
        [Test]
        public void IfStringIsEmptyOrNull_SumReturnZero(string str1, string str2, string expectedResult)
        {
           // To do
        }
    }
}