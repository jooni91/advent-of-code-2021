using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2021.Solutions.Day04
{
    public class BingoBoard
    {
        private readonly (int Number, bool WasCalled)[,] boardGrid = new (int Number, bool WasCalled)[5, 5];

        private bool isWinner = false;
        private int? winningRank = null;
        private int? winningIndex = null;
        private int[] winningNumbers = Array.Empty<int>();

        public BingoBoard(int[,] boardNumbers)
        {
            InitializeBoard(boardNumbers);
        }

        public bool IsWinner => isWinner;
        public int[] WinningNumbers => winningNumbers;
        public IEnumerable<int> UnmarkedNumbers => GetUnmarkedNumbers();

        public void CallNumber(int number)
        {
            if (Any(number, out var index))
            {
                boardGrid[index.Value.X, index.Value.Y].WasCalled = true;

                CheckIfIsWinner();
            }
        }

        private void InitializeBoard(int[,] boardNumbers)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    boardGrid[x, y].Number = boardNumbers[x, y];
                }
            }
        }
        private bool Any(int number, [NotNullWhen(true)] out (int X, int Y)? index)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (boardGrid[x, y].Number == number)
                    {
                        index = (x, y);
                        return true;
                    }
                }
            }

            index = null;

            return false;
        }
        private void CheckIfIsWinner()
        {
            if (SearchForWinningIndex(1, out var index))
            {
                winningRank = 1;
                winningIndex = index;
            }
            else if (SearchForWinningIndex(2, out index))
            {
                winningRank = 2;
                winningIndex = index;
            }

            if (winningRank != null && winningIndex != null)
            {
                isWinner = true;

                winningNumbers = new int[5];

                for (int i = 0; i < 5; i++)
                {
                    if (winningRank == 1)
                    {
                        winningNumbers[i] = boardGrid[(int)winningIndex, i].Number;
                    }
                    else if (winningRank == 2)
                    {
                        winningNumbers[i] = boardGrid[i, (int)winningIndex].Number;
                    }
                }
            }
        }
        private bool SearchForWinningIndex(int rank, [NotNullWhen(true)] out int? index)
        {
            index = null;

            for (int x = 0; x < 5; x++)
            {
                bool allCalled = true;

                for (int y = 0; y < 5; y++)
                {
                    if ((rank == 1 && !boardGrid[x, y].WasCalled) || (rank == 2 && !boardGrid[y, x].WasCalled))
                    {
                        allCalled = false;
                        break;
                    }
                }

                if (allCalled)
                {
                    index = x;
                }
            }

            return index != null;
        }
        private IEnumerable<int> GetUnmarkedNumbers()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (!boardGrid[x, y].WasCalled)
                    {
                        yield return boardGrid[x, y].Number;
                    }
                }
            }
        }
    }
}
