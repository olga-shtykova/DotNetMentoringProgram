using KataTasks;
using NUnit.Framework;

namespace KataTasksTests
{
    public class OddEvenKataTests
    {
        [TestCase(1, 5, "Odd Even 3 Even 5")]
        [Test]
        public void IfAllDataIsValid_ShouldPrintOddEvenAndPrimeNumbers(int num1, int num2, string expectedResult)
        {
            // Arrange/Act
            var result = OddEvenKata.PrintNumbers(num1, num2);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
        
        [TestCase(-1, 10)]
        [Test]
        public void IfFirstParameterIsNegative_ThrowArgumentException(int num1, int num2)
        {
            // Assert
            Assert.That(() => OddEvenKata.PrintNumbers(num1, num2), Throws.Exception);
        }

        [TestCase(1, -10)]
        [Test]
        public void IfSecondParameterIsNegative_ThrowArgumentException(int num1, int num2)
        {
            // Assert
            Assert.That(() => OddEvenKata.PrintNumbers(num1, num2), Throws.Exception);
        }

        [TestCase(5, 1)]
        [Test]
        public void IfSecondParameterIsLessThanTheFirst_ThrowArgumentException(int num1, int num2)
        {
            // Assert
            Assert.That(() => OddEvenKata.PrintNumbers(num1, num2), Throws.Exception);
        }

        [TestCase(0, 10)]
        [Test]
        public void IfFirstParameterIsZero_ThrowArgumentException(int num1, int num2)
        {
            // Assert
            Assert.That(() => OddEvenKata.PrintNumbers(num1, num2), Throws.Exception);
        }

        [TestCase(5, 0)]
        [Test]
        public void IfSecondParameterIsZero_ThrowArgumentException(int num1, int num2)
        {
            // Assert
            Assert.That(() => OddEvenKata.PrintNumbers(num1, num2), Throws.Exception);
        }
    }
}
