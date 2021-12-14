using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Solutions.Day12
{
    public class Cave : IEquatable<Cave?>
    {
        private readonly List<Cave> _connectedCaves = new List<Cave>();
        private readonly string _caveId;

        public Cave(string id)
        {
            _caveId = id;
        }

        public bool IsSmallCave => char.IsLower(_caveId[0]);

        public void AddConnection(Cave cave)
        {
            _connectedCaves.Add(cave);
        }

        public bool Equals(Cave? other)
        {
            return other != null &&
                   _caveId == other._caveId;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Cave);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_caveId);
        }
        public override string ToString()
        {
            return _caveId;
        }

        public static bool operator ==(Cave? left, Cave? right)
        {
            return EqualityComparer<Cave>.Default.Equals(left, right);
        }
        public static bool operator !=(Cave? left, Cave? right)
        {
            return !(left == right);
        }
    }
}
