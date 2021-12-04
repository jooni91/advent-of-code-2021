using AdventOfCode2021.Utilities;
using System;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2021.Solutions.Day03
{
    public class Day3 : DayBase
    {
        protected override string Day => "03";

        protected override string PartOne(string input)
        {
            var inputArray = input.ReadInputLines().ToArray();
            var gammaValue = ConvertBinaryToInt(GetCommonBits(inputArray, CommonType.Most));
            var epsilonValue = ConvertBinaryToInt(GetCommonBits(inputArray, CommonType.Least));

            return (gammaValue * epsilonValue).ToString();
        }

        protected override string PartTwo(string input)
        {
            return "";
        }

        private string GetCommonBits(string[] input, CommonType commonType)
        {
            string output = "";

            for (int y = 0; y < input[0].Length; y++)
            {
                var zeroCount = 0;
                var oneCount = 0;

                for (int x = 0; x < input.Length; x++)
                {
                    if (input[x][y] == '0')
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
                    output += zeroCount > oneCount ? "0" : "1";
                }
                else
                {
                    output += zeroCount < oneCount ? "0" : "1";
                }
            }

            return output;
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
