using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day05
{
    public class Day5 : DayBase
    {
        protected override string Day => "05";
        protected override bool PartOneInputAsStream => true;
        protected override bool PartTwoInputAsStream => true;

        protected override string PartOne(FileStream inputStream)
        {
            var lines = ParseInputWithSpan(inputStream);
            var overlapMap = CreateOverlapMap(lines);

            return overlapMap.Count(item => item.Value >= 2).ToString();
        }

        protected override string PartTwo(FileStream inputStream)
        {
            var lines = ParseInputWithSpan(inputStream);
            var overlapMap = AddDiagonalOverlapsToMap(lines, CreateOverlapMap(lines));

            return overlapMap.Count(item => item.Value >= 2).ToString();
        }

        private Dictionary<Point, int> CreateOverlapMap(Dictionary<Point, Point> lines)
        {
            var map = new Dictionary<Point, int>();

            foreach (var line in lines)
            {
                var xEquals = line.Key.X == line.Value.X;
                var yEquals = line.Key.Y == line.Value.Y;

                if (!xEquals && !yEquals)
                {
                    continue;
                }

                var equalLineValue = xEquals ? line.Key.X : line.Key.Y;
                var min = xEquals ? Math.Min(line.Key.Y, line.Value.Y) : Math.Min(line.Key.X, line.Value.X);
                var max = xEquals ? Math.Max(line.Key.Y, line.Value.Y) : Math.Max(line.Key.X, line.Value.X);
                var length = max - min;

                for (int i = 0; i <= length; i++)
                {
                    var point = xEquals ? new Point(equalLineValue, min + i) : new Point(min + i, equalLineValue);

                    if (map.ContainsKey(point))
                    {
                        map[point]++;
                    }
                    else
                    {
                        map.Add(point, 1);
                    }
                }
            }

            return map;
        }
        private Dictionary<Point, int> AddDiagonalOverlapsToMap(Dictionary<Point, Point> lines, Dictionary<Point, int> map)
        {
            foreach (var line in lines)
            {
                var xEquals = line.Key.X == line.Value.X;
                var yEquals = line.Key.Y == line.Value.Y;

                if (xEquals || yEquals)
                {
                    continue;
                }

                var length = Math.Min(
                    Math.Max(line.Key.X, line.Value.X) - Math.Min(line.Key.X, line.Value.X), 
                    Math.Max(line.Key.Y, line.Value.Y) - Math.Min(line.Key.Y, line.Value.Y));

                for (int i = 0; i <= length; i++)
                {
                    var xVal = line.Key.X < line.Value.X ? line.Key.X + i : line.Key.X - i;
                    var yVal = line.Key.Y < line.Value.Y ? line.Key.Y + i : line.Key.Y - i;

                    var point = new Point(xVal, yVal);

                    if (map.ContainsKey(point))
                    {
                        map[point]++;
                    }
                    else
                    {
                        map.Add(point, 1);
                    }
                }
            }

            return map;
        }
        private Dictionary<Point, Point> ParseInput(FileStream inputStream)
        {
            var output = new Dictionary<Point, Point>();
            using StreamReader sr = new(inputStream);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine()!.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var startPoint = line[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
                var endPoint = line[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                output.Add(new(int.Parse(startPoint[0]), int.Parse(startPoint[1])), new(int.Parse(endPoint[0]), int.Parse(endPoint[1])));
            }

            return output;
        }
        private Dictionary<Point, Point> ParseInputWithSpan(FileStream inputStream)
        {
            var output = new Dictionary<Point, Point>();
            using StreamReader sr = new(inputStream);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().AsSpan();

                output.Add(
                    new(int.Parse(line.Slice(0, line.IndexOf(','))), 
                        int.Parse(line.Slice(line.IndexOf(',') + 1, line.IndexOf('-') - (line.IndexOf(',') + 1)))), 
                    new(int.Parse(line.Slice(line.IndexOf('>') + 2, line.LastIndexOf(',') - (line.IndexOf('>') + 2))), 
                        int.Parse(line.Slice(line.LastIndexOf(',') + 1))));
            }

            return output;
        }
    }
}
