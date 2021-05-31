using System;
using System.Collections.Generic;
using System.Linq;

namespace KataTasks
{
    public class CalcStatsKata
    {
        public double GetStats(List<int> numbers, Value stats)
        {
            if (numbers == null) throw new ArgumentNullException();

            return stats switch
            {
                Value.Minimum => numbers.Min(),
                Value.Maximum => numbers.Max(),
                Value.NumberOfElements => numbers.Count,
                Value.Average => Math.Round(numbers.Average(), 6),
                _ => 0
            };
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
