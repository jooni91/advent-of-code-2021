using AdventOfCode2021.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day01
{
    public class Day1 : DayBase
    {
        protected override string Day => "01";

        protected override string PartOne(string input)
        {
            return LargerMeasurementCount(input.ReadInputLines().ConvertInputsToIntegers()).ToString();
        }

        protected override string PartTwo(string input)
        {
            var measurements = input.ReadInputLines().ConvertInputsToIntegers().ToArray();
            var threeMeasurement = new List<int>();
            var index = 0;

            while (index + 3 <= measurements.Length)
            {
                threeMeasurement.Add(measurements[index..(index + 3)].Sum());
                index++;
            }

            return LargerMeasurementCount(threeMeasurement).ToString();
        }

        private int LargerMeasurementCount(IEnumerable<int> measurements)
        {
            int depthIncreased = 0;
            int previousDepth = 0;

            foreach (var depth in measurements)
            {
                if (previousDepth != 0 && depth > previousDepth)
                {
                    depthIncreased++;
                }

                previousDepth = depth;
            }

            return depthIncreased;
        }
    }
}
