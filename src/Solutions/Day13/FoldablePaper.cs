using AdventOfCode2021.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode2021.Solutions.Day13
{
    public class FoldablePaper
    {
        private readonly HashSet<Vector2> _points = new HashSet<Vector2>();

        private int printFileId = 1;

        public FoldablePaper(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public FoldablePaper(List<Vector2> points)
        {
            _points = points.ToHashSet();

            Width = (int)points.Max(point => point.X);
            Height = (int)points.Max(point => point.Y);
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public IEnumerable<Vector2> Points => _points.AsEnumerable();

        public void FoldUp(int line)
        {
            _points.RemoveWhere(point => point.Y == line);

            for (int i = line + 1; i < Height; i++)
            {
                foreach (var point in _points.Where(point => point.Y == i).ToList())
                {
                    var newPoint = new Vector2(point.X, line - (point.Y - line));

                    if (!_points.Contains(newPoint))
                    {
                        _points.Add(newPoint);
                    }
                }

                _points.RemoveWhere(point => point.Y == i);
            }

            NormalizeNegativePoints();

            Height = line;
        }
        public void FoldLeft(int line)
        {
            _points.RemoveWhere(point => point.X == line);

            for (int i = line + 1; i < Width; i++)
            {
                foreach (var point in _points.Where(point => point.X == i).ToList())
                {
                    var newPoint = new Vector2(line - (point.X - line), point.Y);

                    if (!_points.Contains(newPoint))
                    {
                        _points.Add(newPoint);
                    }
                }

                _points.RemoveWhere(point => point.X == i);
            }

            NormalizeNegativePoints();

            Width = line;
        }
        public void PrintPointsToConsole()
        {
            for (int y = 0; y < Height; y++)
            {
                var sb = new StringBuilder();

                for (int x = 0; x < Width; x++)
                {
                    sb.Append(_points.Contains(new Vector2(x, y)) ? "#" : ".");
                }

                Console.WriteLine(sb.ToString());
            }
        }
        public void PrintToImageFile()
        {
            var bitmap = GraphicsOutput.DrawBitmap(
                ConvertPointsToPrintableDictionary(),
                new Size(Width, Height),
                10f,
                padding: new Size(10, 10),
                borderColor: Color.AliceBlue);

            FileOutput.GenerateImage(bitmap, $"AoC2021_Day13_{printFileId}_generated", @"../../../../images/day13");

            printFileId++;
        }

        private void NormalizeNegativePoints()
        {
            var xNegative = _points.Any(p => p.X < 0);
            var yNegative = _points.Any(p => p.Y < 0);

            if (!xNegative && !yNegative)
            {
                return;
            }

            var pointList = _points.ToList();

            for (int i = _points.Count - 1; i > -1; i--)
            {
                var oldPoint = pointList[i];

                if (xNegative)
                {
                    _points.Add(new Vector2(oldPoint.X + 1, oldPoint.Y));
                    _points.Remove(oldPoint);
                }

                if (yNegative)
                {
                    _points.Add(new Vector2(oldPoint.X, oldPoint.Y + 1));
                    _points.Remove(oldPoint);
                }
            }
        }
        private Dictionary<Vector2, Color> ConvertPointsToPrintableDictionary()
        {
            var dict = new Dictionary<Vector2, Color>();

            foreach (var point in _points)
            {
                dict.Add(point, Color.Black);
            }

            return dict;
        }
    }
}
