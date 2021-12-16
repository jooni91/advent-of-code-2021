namespace AdventOfCode2021.Solutions.Day13
{
    public readonly struct FoldInstruction
    {
        public FoldInstruction(string direction, int line)
        {
            Direction = direction == "x" ? FoldDirection.Left : FoldDirection.Up;
            Line = line;
        }

        public FoldDirection Direction { get; }

        public int Line { get; }
    }
}
