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

        [Test]
        public void ShouldPrintOddEvenAndPrimeNumbers()
        {
            var result = _oddEvenKata.PrintNumbers(); 

            Assert.NotNull(result, $"{result}");
        }
    }
}
