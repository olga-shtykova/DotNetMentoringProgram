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
            // Arrange/Act
            var result = _stringSumKata.Sum(str1, str2);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("27", "100", "127")]
        [Test]
        public void IfDataIsValid_ReturnSum(string str1, string str2, string expectedResult)
        {
            // Arrange/Act
            var result = _stringSumKata.Sum(str1, str2);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}