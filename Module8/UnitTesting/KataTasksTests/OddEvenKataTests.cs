using KataTasks;
using NUnit.Framework;

namespace KataTasksTests
{
    public class OddEvenKataTests
    {
        private OddEvenKata _oddEvenKata;

        [SetUp]
        public void Setup()
        {
            _oddEvenKata = new OddEvenKata();
        }

        [TestCase(1, 100)]
        [Test]
        public void PrintOddEvenAndPrimeNumbers_ResultShouldNotBeNull(int num1, int num2)
        {
            // Arrange/Act
            var result = _oddEvenKata.PrintNumbers(num1, num2);

            // Assert
            Assert.NotNull(result, $"{result}");
        }

        [TestCase(1, 5, "Odd Even 3 Even 5")]
        [Test]
        public void ShouldPrintOddEvenAndPrimeNumbers(int num1, int num2, string expectedResult)
        {
            // Arrange/Act
            var result = _oddEvenKata.PrintNumbers(num1, num2);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase(0, -10)]
        [Test]
        public void IfRangeIsInvalid_ThrowArgumentException(int num1, int num2)
        {
            // Assert
            Assert.That(() => _oddEvenKata.PrintNumbers(num1, num2), Throws.Exception);
        }
    }
}
