using AdventOfCode2021.Utilities;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day06
{
    public class Day6 : DayBase
    {
        protected override string Day => "06";

        protected override string PartOne(string input)
        {
            var fishPool = new LanternfishPool(input.Split(',').ConvertInputsToIntegers().ToArray());

            for (int i = 0; i < 80; i++)
            {
                fishPool.StartNextDay();
            }

            return fishPool.Count.ToString();
        }

        protected override string PartTwo(string input)
        {
            var fishPool = new LanternfishPool(input.Split(',').ConvertInputsToIntegers().ToArray());

            for (int i = 0; i < 256; i++)
            {
                fishPool.StartNextDay();
            }

            return fishPool.Count.ToString();
        }
    }
}
