using AdventOfCode2021.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day14
{
    public class Day14 : DayBase
    {
        protected override string Day => "14";

        protected override string PartOne(string input)
        {
            (string InitialPolymer, Dictionary<string, string> ReactionTable) = ParseInput(input);

            return CalculatePolymerResult(10, InitialPolymer, ReactionTable).ToString();
        }

        protected override string PartTwo(string input)
        {
            (string InitialPolymer, Dictionary<string, string> ReactionTable) = ParseInput(input);

            return CalculatePolymerResult(40, InitialPolymer, ReactionTable).ToString();
        }

        private long CalculatePolymerResult(int steps, string initialPolymer, Dictionary<string, string> reactionTable)
        {
            var charCount = InitializeElementCountTable(initialPolymer);
            var elementPairs = InitializeElementPairTable(initialPolymer);

            for (int i = 0; i < steps; i++)
            {
                var tempElementPairs = new Dictionary<string, long>();

                foreach (var pair in elementPairs)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        var newPair = j == 0
                            ? $"{pair.Key[j]}{reactionTable[pair.Key]}"
                            : $"{reactionTable[pair.Key]}{pair.Key[j]}";

                        if (tempElementPairs.ContainsKey(newPair))
                        {
                            tempElementPairs[newPair] += pair.Value;
                            continue;
                        }

                        tempElementPairs.Add(newPair, pair.Value);
                    }

                    if (charCount.ContainsKey(reactionTable[pair.Key][0]))
                    {
                        charCount[reactionTable[pair.Key][0]] += pair.Value;
                    }
                    else
                    {
                        charCount.Add(reactionTable[pair.Key][0], pair.Value);
                    }
                }

                elementPairs = tempElementPairs;
            }

            return charCount.Max(pair => pair.Value) - charCount.Min(pair => pair.Value);
        }
        private Dictionary<char, long> InitializeElementCountTable(string initialTemplate)
        {
            var dict = new Dictionary<char, long>();

            foreach (var c in initialTemplate)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                    continue;
                }

                dict.Add(c, 1);
            }

            return dict;
        }
        private Dictionary<string, long> InitializeElementPairTable(string initialTemplate)
        {
            var dict = new Dictionary<string, long>();

            for (int i = 1; i < initialTemplate.Length; i++)
            {
                var pair = initialTemplate.Substring(i - 1, 2);

                if (dict.ContainsKey(pair))
                {
                    dict[pair]++;
                    continue;
                }

                dict.Add(pair, 1);
            }

            return dict;
        }
        private (string InitialValue, Dictionary<string, string> ReactionTable) ParseInput(string input)
        {
            var dict = new Dictionary<string, string>();

            foreach (var line in input.ReadInputLines().Skip(2))
            {
                var split = line.Split(" -> ");
                dict.Add(split[0], split[1]);
            }

            return (input.ReadInputLines().First(), dict);
        }
    }
}
