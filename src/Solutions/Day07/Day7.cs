using AdventOfCode2021.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day07
{
    public class Day7 : DayBase
    {
        protected override string Day => "07";

        protected override string PartOne(string input)
        {
            return CalcLeastFuelAmount(input.Split(',').ConvertInputsToIntegers().ToArray()).ToString();
        }

        protected override string PartTwo(string input)
        {
            return CalcLeastFuelAmountPart2(input.Split(',').ConvertInputsToIntegers().ToArray()).ToString();
        }

        private long CalcLeastFuelAmount(int[] input)
        {
            long totalFuelRequired = 0;
            var fuelAmounts = new List<long>();

            for (int i = 0; i < input.Length; i++)
            {
                fuelAmounts.Clear();

                for (int j = 0; j < input.Length; j++)
                {
                    fuelAmounts.Add(Math.Abs(input[j] - input[i]));
                }

                var fuelSum = fuelAmounts.Sum();

                if (i == 0 || fuelSum < totalFuelRequired)
                {
                    totalFuelRequired = fuelSum;
                }
            }

            return totalFuelRequired;
        }
        private long CalcLeastFuelAmountPart2(int[] input)
        {
            long totalFuelRequired = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var fuelAmounts = new List<long>();

                for (int j = 0; j < input.Length; j++)
                {
                    var distance = Math.Abs(input[j] - input[i]);

                    fuelAmounts.Add((distance + 1) * distance / 2);
                }

                var fuelSum = fuelAmounts.Sum();

                if (i == 0 || fuelSum < totalFuelRequired)
                {
                    totalFuelRequired = fuelSum;
                }
            }

            return totalFuelRequired;
        }
    }
}
