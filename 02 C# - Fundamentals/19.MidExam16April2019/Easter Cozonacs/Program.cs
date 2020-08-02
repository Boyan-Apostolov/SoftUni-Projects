using System;

namespace Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double startingBudget = double.Parse(Console.ReadLine());
            double budget = startingBudget;
            double flourPricePerKilo = double.Parse(Console.ReadLine());
            double eggPricePerPack = flourPricePerKilo * 0.75;
            double milkPricePerLitre = flourPricePerKilo * 1.25;
            int eggsCount = 0;
            int cozonacCount = 0;
            int lostEggs = 0;
            int orderCount = 0;
            double priceCozonac = 0;
            priceCozonac = flourPricePerKilo + eggPricePerPack + milkPricePerLitre / 4;
            while (true)
            {
                if (priceCozonac > budget)
                {
                    break;
                }
                else
                {
                    budget -= priceCozonac;
                    cozonacCount++;
                    eggsCount += 3;
                    orderCount++;
                    if (cozonacCount % 3 == 0)
                    {
                        eggsCount -= cozonacCount - 2;
                    }
                }
            }
            Console.WriteLine($"You made {cozonacCount} cozonacs! Now you have {eggsCount} eggs and {budget:f2}BGN left.");
        }
    }
}
