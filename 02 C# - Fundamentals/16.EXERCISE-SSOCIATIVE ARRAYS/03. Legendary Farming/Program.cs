using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {


            Dictionary<string, int> materials = new Dictionary<string, int>();
            Dictionary<string, int> junks = new Dictionary<string, int>();

            string[] items = Console.ReadLine().Split(" ").ToArray();

            int shardsForShadowmourne = 0;
            int fragmentsForValanyr = 0;
            int motesForDragonwrath = 0;

            while (shardsForShadowmourne < 250 || fragmentsForValanyr < 250 || motesForDragonwrath < 250)
            {
                foreach (var ore in items)
                {
                    ore.ToLower();
                }
                
                for (int i = 0; i < items.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        if (!materials.ContainsKey(items[i]))
                        {
                            if (items[i] == "motes")
                            {
                                motesForDragonwrath += int.Parse(items[i - 1]);
                                materials.Add(items[i], motesForDragonwrath);
                            }
                            else if (items[i] == "shards")
                            {
                                shardsForShadowmourne += int.Parse(items[i - 1]);
                                materials.Add(items[i], shardsForShadowmourne);
                            }
                            else if (items[i] == "fragments")
                            {
                                fragmentsForValanyr += int.Parse(items[i - 1]);
                                materials.Add(items[i], fragmentsForValanyr);
                            }
                            else
                            {
                                junks[items[i]]=int.Parse(items[i - 1]);
                            }
                        }
                        else
                        {
                            if (items[i] == "motes")
                            {
                                motesForDragonwrath += int.Parse(items[i - 1]);
                                materials[items[i]]= motesForDragonwrath;
                            }
                            else if (items[i] == "shards")
                            {
                                shardsForShadowmourne += int.Parse(items[i - 1]);
                                materials[items[i]] = shardsForShadowmourne;
                            }
                            else if (items[i] == "fragments")
                            {
                                fragmentsForValanyr += int.Parse(items[i - 1]);
                                materials[items[i]] = fragmentsForValanyr;
                            }
                            else
                            {
                                junks.Add(items[i], int.Parse(items[i - 1]));
                            }
                        }

                    }
                }

                items = Console.ReadLine().Split(" ").ToArray();
            }

            if (shardsForShadowmourne >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                foreach (var material in materials.OrderByDescending(m => m.Value).OrderBy(m => m.Key))
                {
                    int remainingShards = shardsForShadowmourne - 250;
                    int remainingFragments = fragmentsForValanyr - 250;
                    int remainingMotes = motesForDragonwrath - 250;

                    if (material.Key == "shards")
                    {
                        Console.WriteLine($"{material.Key}: {remainingShards}");
                    }
                    else if (material.Key == "fragments")
                    {
                        Console.WriteLine($"{material.Key}: {remainingFragments}");
                    }
                    else if (material.Key == "fragments")
                    {
                        Console.WriteLine($"{material.Key}: {remainingMotes}");
                    }
                }
                foreach (var junk in junks)
                {
                    Console.WriteLine($"{junk.Key}: {junk.Value}");
                }
            }
            else if (fragmentsForValanyr >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                foreach (var material in materials.OrderByDescending(m => m.Value).OrderBy(m => m.Key))
                {
                    int remainingShards = shardsForShadowmourne - 250;
                    int remainingFragments = fragmentsForValanyr - 250;
                    int remainingMotes = motesForDragonwrath - 250;

                    if (material.Key == "shards")
                    {
                        Console.WriteLine($"{material.Key}: {remainingShards}");
                    }
                    else if (material.Key == "fragments")
                    {
                        Console.WriteLine($"{material.Key}: {remainingFragments}");
                    }
                    else if (material.Key == "fragments")
                    {
                        Console.WriteLine($"{material.Key}: {remainingMotes}");
                    }
                }
                foreach (var junk in junks)
                {
                    Console.WriteLine($"{junk.Key}: {junk.Value}");
                }
            }
            else if (motesForDragonwrath >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                foreach (var material in materials.OrderByDescending(m => m.Value).OrderBy(m => m.Key))
                {
                    int remainingShards = shardsForShadowmourne - 250;
                    int remainingFragments = fragmentsForValanyr - 250;
                    int remainingMotes = motesForDragonwrath - 250;

                    if (material.Key == "shards")
                    {
                        Console.WriteLine($"{material.Key}: {remainingShards}");
                    }
                    else if (material.Key == "fragments")
                    {
                        Console.WriteLine($"{material.Key}: {remainingFragments}");
                    }
                    else if (material.Key == "fragments")
                    {
                        Console.WriteLine($"{material.Key}: {remainingMotes}");
                    }
                }
                foreach (var junk in junks)
                {
                    Console.WriteLine($"{junk.Key}: {junk.Value}");
                }
            }

        }
    }
}
