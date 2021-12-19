using AdventOfCode2021.Utilities;
using System;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day17
{
    public class Day17 : DayBase
    {
        protected override string Day => "17";

        protected override string PartOne(string input)
        {
            var y = 0;

            for (int i = 0; i < 89; i++)
            {
                y += 89 - i;
            }

            return y.ToString();
        }

        protected override string PartTwo(string input)
        {
            return "";
        }

        private Rectangle ParseInput(string input)
        {

            return null;
        }
    }
}
