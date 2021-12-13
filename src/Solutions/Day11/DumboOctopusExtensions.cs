using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Solutions.Day11
{
    public static class DumboOctopusExtensions
    {
        public static List<DumboOctopus> ToList(this DumboOctopus[,] octopusMap)
        {
            var list = new List<DumboOctopus>();

            for (int x = 0; x < octopusMap.GetLength(0); x++)
            {
                for (int y = 0; y < octopusMap.GetLength(1); y++)
                {
                    list.Add(octopusMap[x, y]);
                }
            }

            return list;
        }
        public static DumboOctopus[,] AddNeighborsToOctopuses(this DumboOctopus[,] octopusMap)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    octopusMap[x, y].AddNeighbor(TryGetOctopusByIndex(x - 1, y - 1, octopusMap));
                    octopusMap[x, y].AddNeighbor(TryGetOctopusByIndex(x, y - 1, octopusMap));
                    octopusMap[x, y].AddNeighbor(TryGetOctopusByIndex(x + 1, y - 1, octopusMap));
                    octopusMap[x, y].AddNeighbor(TryGetOctopusByIndex(x + 1, y, octopusMap));
                    octopusMap[x, y].AddNeighbor(TryGetOctopusByIndex(x + 1, y + 1, octopusMap));
                    octopusMap[x, y].AddNeighbor(TryGetOctopusByIndex(x, y + 1, octopusMap));
                    octopusMap[x, y].AddNeighbor(TryGetOctopusByIndex(x - 1, y + 1, octopusMap));
                    octopusMap[x, y].AddNeighbor(TryGetOctopusByIndex(x - 1, y, octopusMap));
                }
            }

            return octopusMap;
        }
        public static void IncreaseEnergies(this List<DumboOctopus> octopuses)
        {
            foreach (var octopus in octopuses)
            {
                octopus.IncreaseEnergy();
            }
        }
        public static void Flash(this List<DumboOctopus> octopuses)
        {
            foreach (var octopus in octopuses)
            {
                octopus.CheckEnergyAndFlash();
            }
        }
        public static void Reset(this List<DumboOctopus> octopuses)
        {
            foreach (var octopus in octopuses)
            {
                octopus.Reset();
            }
        }

        private static DumboOctopus? TryGetOctopusByIndex(int x, int y, DumboOctopus[,] octopusMap)
        {
            try
            {
                return octopusMap[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
    }
}
