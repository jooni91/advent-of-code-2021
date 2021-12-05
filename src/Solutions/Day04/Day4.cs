using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day04
{
    public class Day4 : DayBase
    {
        protected override string Day => "04";
        protected override bool PartOneInputAsStream => true;
        protected override bool PartTwoInputAsStream => true;

        protected override string PartOne(FileStream inputStream)
        {
            var (BingoNumbers, BingoBoardNumbers) = ParseInput(inputStream);
            var bingoBoards = CreateBingoBoards(BingoBoardNumbers).ToList();

            var winningNumber = 0;
            var unmarkedSum = 0;

            foreach (var number in BingoNumbers)
            {
                foreach(var board in bingoBoards)
                {
                    board.CallNumber(number);
                }

                if (bingoBoards.Any(board => board.IsWinner))
                {
                    var winner = bingoBoards.First(board => board.IsWinner);
                    winningNumber = number;
                    unmarkedSum = winner.UnmarkedNumbers.Sum();

                    break;
                }
            }

            return $"{winningNumber * unmarkedSum}";
        }
        protected override string PartTwo(FileStream inputStream)
        {
            var (BingoNumbers, BingoBoardNumbers) = ParseInput(inputStream);
            var bingoBoards = CreateBingoBoards(BingoBoardNumbers).ToList();

            var wonBoards = new List<BingoBoard>();
            var winningNumber = 0;
            var unmarkedSum = 0;

            foreach (var number in BingoNumbers)
            {
                foreach (var board in bingoBoards)
                {
                    board.CallNumber(number);
                }

                var winners = bingoBoards.Where(board => board.IsWinner);

                if (winners.Any() && bingoBoards.Count == 1)
                {
                    var winner = bingoBoards.First();
                    winningNumber = number;
                    unmarkedSum = winner.UnmarkedNumbers.Sum();

                    break;
                }
                else if (winners.Any())
                {
                    wonBoards.AddRange(winners);
                    bingoBoards.RemoveAll(board => board.IsWinner);
                }
            }

            return $"{winningNumber * unmarkedSum}";
        }

        private IEnumerable<BingoBoard> CreateBingoBoards(List<int[,]> boardNumbers)
        {
            foreach (var board in boardNumbers)
            {
                yield return new(board);
            }
        }
        private (int[] BingoNumbers, List<int[,]> BingoBoardNumbers) ParseInput(FileStream inputStream)
        {
            using StreamReader sr = new(inputStream);

            var bingoNumbers = sr.ReadLine()!.Split(',').Select(s => int.Parse(s)).ToArray();
            var boardList = new List<int[,]>();

            sr.ReadLine();

            while(!sr.EndOfStream)
            {
                var board = new int[5, 5];

                for (int i = 0; i < 5; i++)
                {
                    var line = sr.ReadLine();
                    var numbers = line!.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < 5; j++)
                    {
                        board[i, j] = int.Parse(numbers[j]);
                    }
                }

                boardList.Add(board);

                sr.ReadLine();
            }

            return (bingoNumbers, boardList);
        }
    }
}
