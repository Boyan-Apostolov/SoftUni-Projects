using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" -> ").ToArray();

                string colour = inputArgs[0];

                string[] clothes = inputArgs[1].Split(",").ToArray();

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe[colour] = new Dictionary<string, int>();

                }

                foreach (var cloth in clothes)
                {
                    if (!wardrobe[colour].ContainsKey(cloth))
                    {
                        wardrobe[colour][cloth] = 0;
                    }

                    wardrobe[colour][cloth]++;
                }
            }

            string[] searchArgs = Console.ReadLine().Split().ToArray();

            string searchColor = searchArgs[0];
            string searchCloth = searchArgs[1];

            foreach (var cdp in wardrobe)
            {
                string color = cdp.Key;
                Dictionary<string, int> clothes = cdp.Value;
                Console.WriteLine($"{color} clothes:");
                foreach (var cqp in  clothes)
                {
                    string cloth = cqp.Key;
                    int qty = cqp.Value;

                    if (color== searchColor && cloth == searchCloth)
                    {
                        Console.WriteLine($"* {cloth} - {qty} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {qty}");
                    }
                }
            }

        }
    }
}
