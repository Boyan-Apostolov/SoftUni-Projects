using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Coctails
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] fres = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> ingredients = new Queue<int>(ingr);
            Stack<int> freshnessLevel = new Stack<int>(fres);

            Dictionary<string, int> madeCoctails = new Dictionary<string, int>();

            madeCoctails.Add("Mimosa", 0);
            madeCoctails.Add("Daiquiri", 0);
            madeCoctails.Add("Sunshine", 0);
            madeCoctails.Add("Mojito", 0);

            while (ingredients.Count != 0 && freshnessLevel.Count != 0)
            {
                int currentIngredient = ingredients.Peek();
                int currentLevel = freshnessLevel.Peek();
                int sum = currentIngredient * currentLevel;
                if (currentIngredient != 0)
                {
                    if (sum == 150)
                    {
                        madeCoctails["Mimosa"]++;
                        freshnessLevel.Pop();
                        ingredients.Dequeue();
                    }
                    else if (sum == 250)
                    {
                        madeCoctails["Daiquiri"]++;
                        freshnessLevel.Pop();
                        ingredients.Dequeue();
                    }
                    else if (sum == 300)
                    {
                        madeCoctails["Sunshine"]++;
                        freshnessLevel.Pop();
                        ingredients.Dequeue();
                    }
                    else if (sum == 400)
                    {
                        madeCoctails["Mojito"]++;
                        freshnessLevel.Pop();
                        ingredients.Dequeue();
                    }
                    else
                    {
                        ingredients.Enqueue(ingredients.Dequeue() + 5);
                        freshnessLevel.Pop();
                    }
                }
                else
                {
                    ingredients.Dequeue();
                }

            }

            if (madeCoctails["Mimosa"] > 0 && madeCoctails["Daiquiri"] > 0 && madeCoctails["Sunshine"] > 0 && madeCoctails["Mojito"] > 0)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
                int sum = 0;
                if (ingredients.Any())
                {
                    sum = ingredients.Sum();
                    Console.WriteLine($"Ingredients left: {sum}");
                }


            }

            foreach (var coctail in madeCoctails.OrderBy(c => c.Key))
            {
                if (coctail.Value > 0)
                {
                    Console.WriteLine($"# {coctail.Key} --> {coctail.Value}");
                }

            }
        }
    }
}
