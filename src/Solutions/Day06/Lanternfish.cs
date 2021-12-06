namespace AdventOfCode2021.Solutions.Day06
{
    /// <summary>
    /// First attempt was making use of this class and we did have a collection of this object.
    /// This did work on the first part for the day but on the second part this was a memory bomb.
    /// 
    /// I had to optimize for the second part and this class is now obsolete, but I will leave it here for nostalgia. :D
    /// </summary>
    public class Lanternfish
    {
        private bool isFirstCycle = true;
        private int daysUntilReproduction = 8;

        public Lanternfish()
        {

        }
        public Lanternfish(int initialDaysUntilReproduction)
        {
            daysUntilReproduction = initialDaysUntilReproduction;
            isFirstCycle = false;
        }

        public bool IsReproductionDay => !isFirstCycle && daysUntilReproduction == 6;

        public void StartNextDay()
        {
            daysUntilReproduction--;

            if (daysUntilReproduction < 0)
            {
                isFirstCycle = false;
                daysUntilReproduction = 6;
            }
        }
    }
}
