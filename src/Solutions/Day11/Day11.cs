using AdventOfCode2021.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day11
{
    public class Day11 : DayBase
    {
        protected override string Day => "11";

        protected override string PartOne(string input)
        {
            var octopuses = ParseInputToMap(input).AddNeighborsToOctopuses().ToList();

            return CountFlashes(100, octopuses).ToString();
        }

        protected override string PartTwo(string input)
        {
            var octopuses = ParseInputToMap(input).AddNeighborsToOctopuses().ToList();

            return CountStepsUntilSynchronization(octopuses).ToString();
        }

        private long CountFlashes(int steps, List<DumboOctopus> octopuses)
        {
            long count = 0;

            for (int i = 0; i < steps; i++)
            {
                octopuses.IncreaseEnergies();

                octopuses.Flash();

                count += octopuses.Count(oct => oct.Flashed);

                octopuses.Reset();
            }

            return count;
        }
        private int CountStepsUntilSynchronization(List<DumboOctopus> octopuses)
        {
            int count = 0;

            while (!octopuses.All(octopus => octopus.Flashed))
            {
                count++;

                octopuses.Reset();
                octopuses.IncreaseEnergies();
                octopuses.Flash();
            }

            return count;
        }
        private DumboOctopus[,] ParseInputToMap(string input)
        {
            var inputArray = input.ReadInputLines().ToArray();
            var map = new DumboOctopus[10, 10];

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    map[x, y] = new DumboOctopus(Convert.ToInt32(inputArray[y][x].ToString()));
                }
            }

            return map;
        }
    }
}
