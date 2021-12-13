using System.Collections.Generic;

namespace AdventOfCode2021.Solutions.Day11
{
    public class DumboOctopus
    {
        private readonly List<DumboOctopus> _neighbors = new List<DumboOctopus>();
        private int energyLevel;

        public DumboOctopus(int initialEnergy)
        {
            energyLevel = initialEnergy;
        }

        public bool Flashed { get; set; }

        public void AddNeighbor(DumboOctopus? dumboOctopus)
        {
            if (dumboOctopus == null)
            {
                return;
            }

            _neighbors.Add(dumboOctopus);
        }

        public void Reset()
        {
            if (energyLevel > 9)
            {
                energyLevel = 0;
            }

            Flashed = false;
        }
        public void IncreaseEnergy()
        {
            energyLevel++;
        }
        public void NeighborFlashed()
        {
            IncreaseEnergy();
            CheckEnergyAndFlash();
        }
        public void CheckEnergyAndFlash()
        {
            if (!Flashed && energyLevel > 9)
            {
                Flashed = true;

                foreach (var octopus in _neighbors)
                {
                    octopus.NeighborFlashed();
                }
            }
        }
    }
}
