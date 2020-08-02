using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> parts = Console.ReadLine().Split('|').ToList();
            string[] commandArgs = Console.ReadLine().Split(" ").ToArray();

            while (commandArgs[0] != "Done")
            {
                switch (commandArgs[0])
                {
                    case "Move":
                        if (commandArgs[1] == "Left")
                        {
                            int indexToMove = int.Parse(commandArgs[2]);
                            string temp = null;

                            if (indexToMove > 0 && indexToMove <= parts.Count-1)
                            {
                                temp = parts[indexToMove - 1];
                                parts[indexToMove - 1] = parts[indexToMove];
                                parts[indexToMove] = temp;

                            }


                        }
                        else if (commandArgs[1] == "Right")
                        {
                            int indexToMove = int.Parse(commandArgs[2]);
                            string temp = null;
                            if (indexToMove >= 0 && indexToMove <= parts.Count-2)
                            {
                                temp = parts[indexToMove + 1];
                                parts[indexToMove + 1] = parts[indexToMove];
                                parts[indexToMove] = temp;
                            }

                        }
                        break;

                    case "Check":
                        if (commandArgs[1] == "Even")
                        {
                            for (int i = 0; i <= parts.Count - 1; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    Console.Write(parts[i] + " ");
                                    
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (commandArgs[1] == "Odd")
                        {
                            for (int i = 0; i <= parts.Count - 1; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    Console.Write(parts[i] + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        break;
                }
                commandArgs = Console.ReadLine().Split(" ").ToArray();
            }

            Console.WriteLine($"You crafted {string.Join("", parts)}!");

        }
    }
}
