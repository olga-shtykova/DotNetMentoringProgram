using KataTasks;
using NUnit.Framework;

namespace KataTasksTests
{
    public class StringSumKataTests
    {
        [TestCase(null, "", "0")]
        [Test]
        public void IfStringIsEmptyOrNull_SumReturnZero(string str1, string str2, string expectedResult)
        {
            // Arrange/Act
            var result = StringSumKata.Sum(str1, str2);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("2", "4", "0")]
        [Test]
        public void IfNumbersAreNotPrime_ReturnZero(string str1, string str2, string expectedResult)
        {
            // Arrange/Act
            var result = StringSumKata.Sum(str1, str2);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("5", "7", "12")]
        [Test]
        public void IfDataIsValid_ReturnSum(string str1, string str2, string expectedResult)
        {
            // Arrange/Act
            var result = StringSumKata.Sum(str1, str2);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("2147483647", "2147483647", "4294967294")]
        [Test]
        public void IfStringValueIsIntMaxValue_ReturnSum(string str1, string str2, string expectedResult)
        {
            // Arrange/Act
            var result = StringSumKata.Sum(str1, str2);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("-795", "B77")]
        [Test]
        public void IfDataIsInvalid_ThrowArgumentException(string str1, string str2)
        {
            // Assert
            Assert.That(() => StringSumKata.Sum(str1, str2), Throws.Exception);
        }
    }
}