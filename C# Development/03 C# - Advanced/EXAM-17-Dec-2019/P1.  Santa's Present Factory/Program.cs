using System;
using System.Linq;
using System.Collections.Generic;
namespace P1.__Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] magics = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> materials = new Stack<int>(boxes);
            Queue<int> magic = new Queue<int>(magics);

            Dictionary<string, int> craftedPresetsTAGS = new Dictionary<string, int>();

            


            List<string> craftedPResents = new List<string>();

            while (materials.Count != 0 && magic.Count != 0)
            {
                int currentMaterial = materials.Peek();
                int currentMagic = magic.Peek();

                int multiplication = currentMagic * currentMaterial;

                if (multiplication == 150)
                {
                    craftedPResents.Add("Doll");
                    if (!craftedPresetsTAGS.ContainsKey("Doll"))
                    {
                        craftedPresetsTAGS.Add("Doll", 0);
                    }
                    craftedPresetsTAGS["Doll"]++;
                    materials.Pop();
                    magic.Dequeue();
                }
                else if (multiplication == 250)
                {
                    craftedPResents.Add("Wooden train");
                    if (!craftedPresetsTAGS.ContainsKey("Wooden train"))
                    {
                        craftedPresetsTAGS.Add("Wooden train", 0);
                    }
                    craftedPresetsTAGS["Wooden train"]++;
                    materials.Pop();
                    magic.Dequeue();
                }
                else if (multiplication == 300)
                {
                    craftedPResents.Add("Teddy bear");
                    if (!craftedPresetsTAGS.ContainsKey("Teddy bear"))
                    {
                        craftedPresetsTAGS.Add("Teddy bear", 0);
                    }
                    craftedPresetsTAGS["Teddy bear"]++;
                    materials.Pop();
                    magic.Dequeue();
                }
                else if (multiplication == 400)
                {
                    craftedPResents.Add("Bicycle");
                    if (!craftedPresetsTAGS.ContainsKey("Bicycle"))
                    {
                        craftedPresetsTAGS.Add("Bicycle", 0);
                    }
                    craftedPresetsTAGS["Bicycle"]++;
                    materials.Pop();
                    magic.Dequeue();
                }

                if (multiplication < 0)
                {
                    int sum = currentMaterial + currentMagic;
                    materials.Pop();
                    magic.Dequeue();
                    materials.Push(sum);
                }
                else if ((multiplication > 0 && multiplication != 150) && (multiplication > 0 && multiplication != 250) && (multiplication > 0 && multiplication != 300) && (multiplication > 0 && multiplication != 400) )
                {
                    magic.Dequeue();
                    materials.Push(materials.Pop() + 15);
                }

                if (currentMagic ==0 || currentMaterial ==0)
                {
                    if (currentMaterial == 0)
                    {
                        materials.Pop();
                    }
                    if (currentMagic == 0)
                    {
                        magic.Dequeue();
                    }
                }
            }

            bool isSuccessful = false;

            if (craftedPResents.Contains("Doll") && craftedPResents.Contains("Wooden train") || craftedPResents.Contains("Teddy bear") && craftedPResents.Contains("Bicycle"))
            {
                isSuccessful = true;
            }
            else 
            {
                isSuccessful = false;
            }

            if (isSuccessful)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ",materials)}");
            }

            if (magic.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }

            foreach (var present in craftedPresetsTAGS.OrderBy(n=> n.Key))
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }
        }
    }
}
