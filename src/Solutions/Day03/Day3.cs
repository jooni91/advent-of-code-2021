using AdventOfCode2021.Utilities;
using System;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day03
{
    public class Day3 : DayBase
    {
        protected override string Day => "03";

        protected override string PartOne(string input)
        {
            var inputArray = input.ReadInputLines().ToArray();
            var gammaValue = ConvertBinaryToInt(GetCommonerBits(ref inputArray, CommonType.Most));
            var epsilonValue = ConvertBinaryToInt(GetCommonerBits(ref inputArray, CommonType.Least));

            return (gammaValue * epsilonValue).ToString();
        }

        protected override string PartTwo(string input)
        {
            var inputArray = input.ReadInputLines().ToArray();

            return $"{GetOxygenGeneratorRating(inputArray) * GetCo2ScrubberRating(inputArray)}";
        }

        private string GetCommonerBits(ref string[] input, CommonType commonType)
        {
            string output = "";

            for (int x = 0; x < input[0].Length; x++)
            {
                output += GetBitValueByCommoner(ref input, x, commonType);
            }

            return output;
        }
        private int GetOxygenGeneratorRating(string[] input)
        {
            for (int xIndex = 0; xIndex < input[0].Length; xIndex++)
            {
                var commonBit = GetBitValueByCommoner(ref input, xIndex, CommonType.Most);

                input = input.Where(bits => bits[xIndex] == commonBit).ToArray();

                if (input.Length == 1)
                {
                    break;
                }
            }

            return ConvertBinaryToInt(input[0]);
        }
        private int GetCo2ScrubberRating(string[] input)
        {
            for (int xIndex = 0; xIndex < input[0].Length; xIndex++)
            {
                var commonBit = GetBitValueByCommoner(ref input, xIndex, CommonType.Least);

                input = input.Where(bits => bits[xIndex] == commonBit).ToArray();

                if (input.Length == 1)
                {
                    break;
                }
            }

            return ConvertBinaryToInt(input[0]);
        }
        private char GetBitValueByCommoner(ref string[] input, int xIndex, CommonType commonType)
        {
            var zeroCount = 0;
            var oneCount = 0;

            for (int y = 0; y < input.Length; y++)
            {
                if (input[y][xIndex] == '0')
                {
                    zeroCount++;
                }
                else
                {
                    oneCount++;
                }
            }

            if (commonType == CommonType.Most)
            {
                return oneCount >= zeroCount ? '1' : '0';
            }
            else
            {
                return zeroCount <= oneCount ? '0' : '1';
            }
        }
        private int ConvertBinaryToInt(string binaryString)
        {
            return Convert.ToInt32(binaryString, 2);
        }
    }

    public enum CommonType
    {
        Most,
        Least
    }
}
