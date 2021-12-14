using AdventOfCode2021.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day12
{
    public class Day12 : DayBase
    {
        protected override string Day => "12";

        protected override string PartOne(string input)
        {
            var caveMap = ParseInput(input);

            return "";
        }

        protected override string PartTwo(string input)
        {
            return "";
        }

        private HashSet<Cave> ParseInput(string input)
        {
            var caves = new HashSet<Cave>();

            foreach (var line in input.ReadInputLines())
            {
                var caveIds = line.Split('-');
                var cave1 = new Cave(caveIds[0]);
                var cave2 = new Cave(caveIds[1]);

                if (caves.Contains(cave1))
                {
                    cave1 = caves.First(c => c == cave1);
                }
                else
                {
                    caves.Add(cave1);
                }

                if (caves.Contains(cave2))
                {
                    cave2 = caves.First(c => c == cave2);
                }
                else
                {
                    caves.Add(cave2);
                }

                cave1.AddConnection(cave2);
                cave2.AddConnection(cave1);
            }

            return caves;
        }
    }
}
