using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine().Split(' ').ToList();
            int commands = int.Parse(Console.ReadLine());
            int executeCommands = 0;

            while (commands > 0)
            {
                string[] currentCommand = Console.ReadLine().Split(' ').ToArray();
                switch (currentCommand[0])
                {
                    case "Include":
                        string shopToAddAtEnd = currentCommand[1];
                        shops.Add(shopToAddAtEnd);
                        break;

                    case "Visit":
                        if (currentCommand[1] == "first")
                        {
                            int numberOfShops = int.Parse(currentCommand[2]);
                            if (numberOfShops <= shops.Count && numberOfShops >= 0)
                            {
                                shops.RemoveRange(0, numberOfShops);
                            }
                        }
                        else
                        {
                            int numberOfShops = int.Parse(currentCommand[2]);
                            if (numberOfShops <= shops.Count && numberOfShops >= 0)
                            {
                                shops.RemoveRange(shops.Count - numberOfShops, numberOfShops);
                            }
                        }
                        break;

                    case "Prefer":
                        int shopIndex1 = int.Parse(currentCommand[1]);
                        int shopIndex2 = int.Parse(currentCommand[2]);

                        if (shopIndex1 <= shops.Count && shopIndex1 >= 0 
                            && shopIndex2 <= shops.Count && shopIndex2 >= 0)
                        {
                            string temp = shops[shopIndex1];
                            shops[shopIndex1] = shops[shopIndex2];
                            shops[shopIndex2] = temp;

                        }

                        break;

                    case "Place":
                        string shopToAdd = currentCommand[1];
                        int indexToAdd = int.Parse(currentCommand[2]);

                        if (indexToAdd <= shops.Count && indexToAdd >= 0)
                        {
                            shops.Insert(indexToAdd+1, shopToAdd);
                        }
                        break;
                    default:
                        break;
                }


                commands--;
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ",shops));
        }
    }
}
