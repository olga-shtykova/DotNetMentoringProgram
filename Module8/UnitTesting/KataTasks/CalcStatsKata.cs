using System;
using System.Collections.Generic;
using System.Linq;

namespace KataTasks
{
    public class CalcStatsKata
    {
        public double GetStats(List<int> numbers, Value stats)
        {
            switch (stats)
            {
                case Value.Minimum:
                    return numbers.Min();
                case Value.Maximum:
                    return numbers.Max();
                case Value.NumberOfElements:
                    return numbers.Count;
                case Value.Average:
                    return Math.Round(numbers.Average(), 6);
            }
            return 0;
        }

        public enum Value
        {
            Minimum = 1,
            Maximum = 2,
            NumberOfElements = 3,
            Average = 4
        }
    }
}
