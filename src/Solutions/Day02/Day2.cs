using AdventOfCode2021.Utilities;
using System;
using System.Numerics;

namespace AdventOfCode2021.Solutions.Day02
{
    public class Day2 : DayBase
    {
        protected override string Day => "02";

        protected override string PartOne(string input)
        {
            var point = new Vector2();

            foreach (var instruction in input.ReadInputLines())
            {
                var splitInstruction = instruction.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                point = splitInstruction[0] switch
                {
                    "forward" => new Vector2(point.X + int.Parse(splitInstruction[1]), point.Y),
                    "down" => new Vector2(point.X, point.Y + int.Parse(splitInstruction[1])),
                    "up" => new Vector2(point.X, point.Y - int.Parse(splitInstruction[1])),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            return (point.X * point.Y).ToString();
        }

        protected override string PartTwo(string input)
        {
            var point = new Vector2();
            var aim = 0;

            foreach (var instruction in input.ReadInputLines())
            {
                var splitInstruction = instruction.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (splitInstruction[0])
                {
                    case "down":
                        aim += int.Parse(splitInstruction[1]);
                        break;
                    case "up":
                        aim -= int.Parse(splitInstruction[1]);
                        break;
                    case "forward":
                        point = new Vector2(point.X + int.Parse(splitInstruction[1]), point.Y + (aim * int.Parse(splitInstruction[1])));
                        break;
                }
            }

            return ((long)point.X * (long)point.Y).ToString();
        }
    }
}
