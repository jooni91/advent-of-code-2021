using AdventOfCode2021.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2021.Solutions.Day13
{
    public class Day13 : DayBase
    {
        protected override string Day => "13";

        protected override string PartOne(string input)
        {
            (List<Vector2> Map, List<FoldInstruction> FoldInstructions) = ParseInput(input);
            var paper = new FoldablePaper(Map);

            if (FoldInstructions.First().Direction == FoldDirection.Up)
            {
                paper.FoldUp(FoldInstructions.First().Line);
            }
            else
            {
                paper.FoldLeft(FoldInstructions.First().Line);
            }

            return paper.Points.Count().ToString();
        }

        protected override string PartTwo(string input)
        {
            (List<Vector2> Map, List<FoldInstruction> FoldInstructions) = ParseInput(input);
            var paper = new FoldablePaper(Map);

            foreach (var instruction in FoldInstructions)
            {
                if (instruction.Direction == FoldDirection.Up)
                {
                    paper.FoldUp(instruction.Line);
                }
                else
                {
                    paper.FoldLeft(instruction.Line);
                }

                if (Debugger.IsAttached)
                {
                    paper.PrintToImageFile();
                }
            }

            paper.PrintPointsToConsole();

            return paper.Points.Count().ToString();
        }

        private (List<Vector2> Map, List<FoldInstruction> FoldInstructions) ParseInput(string input)
        {
            var map = new List<Vector2>();
            var instructions = new List<FoldInstruction>();

            var readingInstructions = false;

            foreach (var line in input.ReadInputLines())
            {
                if (!readingInstructions && string.IsNullOrEmpty(line))
                {
                    readingInstructions = true;
                    continue;
                }

                if (!readingInstructions)
                {
                    var coords = line.Split(',');

                    map.Add(new Vector2(int.Parse(coords[0]), int.Parse(coords[1])));
                }
                else
                {
                    var instruct = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2].Split('=');

                    instructions.Add(new FoldInstruction(instruct[0], int.Parse(instruct[1])));
                }
            }

            return (map, instructions);
        }
    }
}
