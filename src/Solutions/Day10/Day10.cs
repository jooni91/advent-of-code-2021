using AdventOfCode2021.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day10
{
    public class Day10 : DayBase
    {
        protected override string Day => "10";

        protected override string PartOne(string input)
        {
            return CheckScoreForCorruptedLines(input).ToString();
        }

        protected override string PartTwo(string input)
        {
            return CheckScoreForIncompleteLines(input).ToString();
        }

        private long CheckScoreForCorruptedLines(string input)
        {
            var openings = new List<char>();
            var firstIllegalChars = new List<char>();

            foreach (var line in input.ReadInputLines())
            {
                foreach (var symbol in line)
                {
                    if (IsOpening(symbol))
                    {
                        openings.Add(symbol);
                        continue;
                    }

                    if (ClosingMatchesOpening(openings.Last(), symbol))
                    {
                        openings.RemoveAt(openings.Count - 1);
                        continue;
                    }

                    firstIllegalChars.Add(symbol);
                    break;
                }
            }

            return CalculateCorruptScore(firstIllegalChars);
        }
        private long CheckScoreForIncompleteLines(string input)
        {
            var incompleteLines = FilterOutCorruptedLines(input.ReadInputLines());

            return CalculateAutoCorrectScore(incompleteLines);
        }
        private bool IsOpening(char symbol)
        {
            return symbol switch
            {
                '(' or '{' or '[' or '<' => true,
                _ => false
            };
        }
        private char GetOpeningOpposite(char opening)
        {
            return opening switch
            {
                '(' => ')',
                '{' => '}',
                '[' => ']',
                '<' => '>',
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        private long CalculateCorruptScore(List<char> illegalClosings)
        {
            var score = 0;

            foreach (var closing in illegalClosings)
            {
                _ = closing switch
                {
                    ')' => score += 3,
                    ']' => score += 57,
                    '}' => score += 1197,
                    '>' => score += 25137,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            return score;
        }
        private long CalculateAutoCorrectScore(List<List<char>> autoCompleteLines)
        {
            var scores = new List<long>();

            foreach (var line in autoCompleteLines)
            {
                var score = 0L;
                
                foreach (var closing in line.Reverse<char>())
                {
                    score *= 5;

                    _ = closing switch
                    {
                        '(' => score += 1,
                        '[' => score += 2,
                        '{' => score += 3,
                        '<' => score += 4,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }

                scores.Add(score);
            }

            scores.Sort();

            return scores[scores.Count / 2];
        }
        private bool ClosingMatchesOpening(char openingSymbol, char closingSymbol)
        {
            return closingSymbol == GetOpeningOpposite(openingSymbol);
        }
        private List<List<char>> FilterOutCorruptedLines(IEnumerable<string> lines)
        {
            var incompleteLines = new List<List<char>>();

            foreach (var line in lines)
            {
                var openings = new List<char>();

                foreach (var symbol in line)
                {
                    if (IsOpening(symbol))
                    {
                        openings.Add(symbol);
                    }
                    else if (ClosingMatchesOpening(openings.Last(), symbol))
                    {
                        openings.RemoveAt(openings.Count - 1);
                    }
                    else
                    {
                        openings.Clear();
                        break;
                    }
                }

                if (openings.Count > 0)
                {
                    incompleteLines.Add(openings);
                }
            }

            return incompleteLines;
        }
    }
}
