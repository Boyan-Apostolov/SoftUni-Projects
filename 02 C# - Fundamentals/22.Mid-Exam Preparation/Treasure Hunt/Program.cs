using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("| ").ToList();

            string input = null;
            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                List<string> commandArgs = input.Split("| ").ToList();
                string command = commandArgs[0];

                switch (command)
                {
                    case "Loot":
                        string[] items = commandArgs.Skip(1).ToArray();
                        LootChest(items, chest);
                        break;

                    case "Drop":
                        int index = int.Parse(commandArgs[1]);
                        DropChest(index, chest);
                        break;

                    case "Steal":
                        int count = int.Parse(commandArgs[1]);
                        StealChest(count, chest);
                        break;
                    default:
                        break;
                }
            }
           
            double average = GetAverageSum(chest);

            if (chest.Count != 0)
            {
                Console.WriteLine($"Average treasure gain: {average:f2} pirate credits.");

            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }


        }

        private static double GetAverageSum(List<string> chest)
        {
            double sum = 0.0;
            foreach (string item in chest)
            {
                sum = item.Length;

            }
            double average = sum / chest.Count;
            return average;
        }

        private static void StealChest(int count, List<string> chest)
        {
            int index = chest.Count - count;

            //string[] deletedItems = chest.Skip(index).ToArray();
            //Console.WriteLine(string.Join(", ", deletedItems));

            string[] deletedItems = null;


            if (index >= 0)
            {
                deletedItems = chest.Skip(index).ToArray();
                chest.RemoveRange(index, count);
            }
            else
            {
                deletedItems = chest.ToArray();
                chest.Clear();
            }
            
            Console.WriteLine(string.Join(", ", deletedItems));
        }

        private static void DropChest(int index, List<string> chest)
        {
            if (IsValidIndex(index, chest))
            {
                string item = chest[index];
                chest.RemoveAt(index);
                chest.Add(item);
            }
        }

        private static bool IsValidIndex(int index, List<string> list)
        {
            return index < list.Count && index >= 0;
        }

        private static void LootChest(string[] items, List<string> chest)
        {
            foreach (string item in items)
            {

                if (!chest.Contains(item))
                {
                    chest.Insert(0, item);
                }
            }
        }
    }


    //    using System;
    //using System.Collections.Generic;
    //using System.Linq;

    //namespace Treasure_Hunt
    //    {
    //        class Program
    //        {
    //            static void Main(string[] args)
    //            {
    //                List<string> myList = Console.ReadLine().Split("|").ToList<string>();

    //                string command = Console.ReadLine();

    //                while (command != "Yohoho!")
    //                {
    //                    List<string> currentCommand = command.Split().ToList();

    //                    if (currentCommand[0] == "Loot")
    //                    {
    //                        for (int i = 1; i < currentCommand.Count; i++)
    //                        {
    //                            if (myList.Contains(currentCommand[i]) == false)
    //                            {
    //                                myList.Insert(0, currentCommand[i]);
    //                            }
    //                        }
    //                    }
    //                    else if (currentCommand[0] == "Drop")
    //                    {
    //                        int index = int.Parse(currentCommand[1]);
    //                        if (index >= 0 & index < myList.Count)
    //                        {
    //                            string lastElement = myList[index];
    //                            myList.Remove(myList[index]);
    //                            myList.Add(lastElement);
    //                        }
    //                    }
    //                    else if (currentCommand[0] == "Steal")
    //                    {
    //                        int count = int.Parse(currentCommand[1]);

    //                        if (count > myList.Count)
    //                        {
    //                            count = myList.Count;
    //                            List<string> newList = new List<string>();
    //                            for (int i = 0; i < count; i++)
    //                            {
    //                                newList.Add(myList[myList.Count - 1]);
    //                                myList.Remove(myList[myList.Count - 1]);
    //                            }
    //                            newList.Reverse();
    //                            Console.WriteLine(string.Join(", ", newList));
    //                        }
    //                        else
    //                        {
    //                            List<string> newList = new List<string>();
    //                            for (int i = 0; i < count; i++)
    //                            {
    //                                newList.Add(myList[myList.Count - 1]);
    //                                myList.Remove(myList[myList.Count - 1]);
    //                            }
    //                            newList.Reverse();
    //                            Console.WriteLine(string.Join(", ", newList));
    //                        }
    //                    }

    //                    command = Console.ReadLine();
    //                }

    //                if (command == "Yohoho!")
    //                {
    //                    if (myList.Count == 0)
    //                    {
    //                        Console.WriteLine($"Failed treasure hunt.");
    //                    }
    //                    else
    //                    {
    //                        double sum = 0.0;
    //                        for (int i = 0; i < myList.Count; i++)
    //                        {
    //                            sum += myList[i].Count();
    //                        }
    //                        double averageGain = sum / myList.Count();
    //                        Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
    //                    }
    //                }
    //            }
    //        }
    //    }
}
