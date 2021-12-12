using AdventOfCode2021.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day09
{
    public class Day9 : DayBase
    {
        protected override string Day => "09";

        protected override string PartOne(string input)
        {
            var lowestPoints = GetLowestPointHeights(ParseInput(input.ReadInputLines().ToArray()));

            return (lowestPoints.Count + lowestPoints.Sum()).ToString();
        }

        protected override string PartTwo(string input)
        {


            return "";
        }

        private List<int> GetLowestPointHeights(int[,] map)
        {
            var lowestHeights = new List<int>();

            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    var currentVal = map[x, y];

                    if (TryGetHeightValue(x, y - 1, map) > currentVal &&
                        TryGetHeightValue(x, y + 1, map) > currentVal &&
                        TryGetHeightValue(x - 1, y, map) > currentVal &&
                        TryGetHeightValue(x + 1, y, map) > currentVal)
                    {
                        lowestHeights.Add(currentVal);
                    }
                }
            }

            return lowestHeights;
        }
        private int TryGetHeightValue(int x, int y, int[,] map)
        {
            try
            {
                return map[x, y];
            }
            catch(IndexOutOfRangeException)
            {
                return 10;
            }
        }
        private int[,] ParseInput(string[] inputLines)
        {
            var map = new int[inputLines.Length, inputLines[0].Length];

            for (int y = 0; y < inputLines.Length; y++)
            {
                for (int x = 0; x < inputLines[y].Length; x++)
                {
                    map[x, y] = int.Parse(inputLines[y][x].ToString());
                }
            }

            return map;
        }
    }
}
