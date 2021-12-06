using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions.Day06
{
    public class LanternfishPool
    {
        private readonly Dictionary<int, long> _lanternfishes = new() { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 } };

        public LanternfishPool(int[] initialFish)
        {
            foreach (var days in initialFish)
            {
                _lanternfishes[days]++;
            }
        }

        public long Count => _lanternfishes.Sum(pair => pair.Value);

        public void StartNextDay()
        {
            var tempFishPool = new long[9];

            for (int i = _lanternfishes.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    tempFishPool[8] = _lanternfishes[i];
                    tempFishPool[6] += _lanternfishes[i];
                    continue;
                }

                tempFishPool[i - 1] = _lanternfishes[i];
            }

            for (int i = 0; i < _lanternfishes.Count; i++)
            {
                _lanternfishes[i] = tempFishPool[i];
            }
        }
    }
}
