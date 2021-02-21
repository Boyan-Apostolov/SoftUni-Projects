using System;
using System.Collections.Generic;
using System.Linq;
namespace P1._Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vodi = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] predmeti = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> items = new Stack<int>(predmeti);
            Queue<int> liquids = new Queue<int>(vodi);

            Dictionary<string, int> craftedThings = new Dictionary<string, int>();
            craftedThings.Add("Glass", 0);
            craftedThings.Add("Aluminium", 0);
            craftedThings.Add("Lithium", 0);
            craftedThings.Add("Carbon fiber", 0);

            while (items.Count != 0 && liquids.Count != 0)
            {
                int currentItem = items.Peek();
                int currentLiquid = liquids.Peek();
                int sum = currentItem + currentLiquid;

                if (sum == 25)
                {
                    craftedThings["Glass"]++;
                    items.Pop();
                    liquids.Dequeue();
                }
                else if (sum == 50)
                {
                    craftedThings["Aluminium"]++;
                    items.Pop();
                    liquids.Dequeue();
                }
                else if (sum == 75)
                {
                    craftedThings["Lithium"]++;
                    items.Pop();
                    liquids.Dequeue();
                }
                else if (sum == 100)
                {
                    craftedThings["Carbon fiber"]++;
                    items.Pop();
                    liquids.Dequeue();
                }
                else
                {
                    liquids.Dequeue();
                    items.Push(items.Pop() + 3);
                }
            }

            //Printing
            if (craftedThings["Glass"] >= 1 && craftedThings["Aluminium"] >= 1 && craftedThings["Carbon fiber"] >= 1 && craftedThings["Lithium"] >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (items.Any())
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var item in craftedThings.OrderBy(n=>n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
