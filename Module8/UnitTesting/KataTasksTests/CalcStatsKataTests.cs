using System.Collections.Generic;
using KataTasks;
using NUnit.Framework;

namespace KataTasksTests
{
    public class CalcStatsKataTests
    {
        private CalcStatsKata _calcStatsKata;
        private List<int> _list;

        [SetUp]
        public void Setup()
        {
            _calcStatsKata = new CalcStatsKata();
            _list = new List<int> { 6, 9, 15, -2, 92, 11 };
        }
        
        [Test]
        public void ShouldReturnMinValue()
        {
            // Arrange
            double expectedResult = -2;

            // Act
            var result = _calcStatsKata.GetStats(_list, CalcStatsKata.Value.Minimum);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void ShouldReturnMaxValue()
        {
            // Arrange
            double expectedResult = 92;

            // Act
            var result = _calcStatsKata.GetStats(_list, CalcStatsKata.Value.Maximum);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void ShouldReturnNamberOfElements()
        {
            // Arrange
            double expectedResult = 6;

            // Act
            var result = _calcStatsKata.GetStats(_list, CalcStatsKata.Value.NumberOfElements);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void ShouldReturnAverageValue()
        {
            // Arrange
            double expectedResult = 21.833333;

            // Act
            var result = _calcStatsKata.GetStats(_list, CalcStatsKata.Value.Average);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
        
        [Test]
        public void IfValueIsZero_ShouldReturnZero()
        {
            // Arrange
            double expectedResult = 0;

            // Act
            var result = _calcStatsKata.GetStats(_list, 0);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}
