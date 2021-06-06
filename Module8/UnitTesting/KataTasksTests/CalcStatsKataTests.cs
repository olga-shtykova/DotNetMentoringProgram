using System.Collections.Generic;
using KataTasks;
using NUnit.Framework;

namespace KataTasksTests
{
    public class CalcStatsKataTests
    {
        private List<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new List<int> { 6, 9, 15, -2, 92, 11 };
        }
        
        [Test]
        public void ShouldReturnMinValue()
        {
            // Arrange/Act
            var result = CalcStatsKata.GetStats(_list, CalcStatsKata.Value.Minimum);

            // Assert
            double expectedResult = -2;
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void ShouldReturnMaxValue()
        {
            // Arrange/Act
            var result = CalcStatsKata.GetStats(_list, CalcStatsKata.Value.Maximum);

            // Assert
            double expectedResult = 92;
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void ShouldReturnNumberOfElements()
        {
            // Arrange/Act
            var result = CalcStatsKata.GetStats(_list, CalcStatsKata.Value.NumberOfElements);

            // Assert
            double expectedResult = 6;
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void ShouldReturnAverageValue()
        {
            // Arrange/Act
            var result = CalcStatsKata.GetStats(_list, CalcStatsKata.Value.Average);

            // Assert
            double expectedResult = 21.833333;
            Assert.That(expectedResult, Is.EqualTo(result));
        }
        
        [Test]
        public void IfValueIsZero_ThrowArgumentException()
        {
            // Assert
            Assert.That(() => CalcStatsKata.GetStats(_list, 0), Throws.Exception);
        }

        [Test]
        public void IfSequenceOfIntegerNumbersIsNull_ThrowArgumentNullException()
        {
            // Assert
            Assert.That(() =>
                    CalcStatsKata.GetStats(null, CalcStatsKata.Value.Maximum),
                Throws.ArgumentNullException);
        }
    }
}
