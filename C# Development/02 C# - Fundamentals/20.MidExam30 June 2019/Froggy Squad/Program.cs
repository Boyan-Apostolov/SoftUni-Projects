using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine().Split(' ').ToList();

            string[] commandArgs = Console.ReadLine().Split(' ').ToArray();

            while (commandArgs[0] != "Print")
            {
                switch (commandArgs[0])
                {
                    case "Join":
                        string incommingFrog = commandArgs[1];
                        frogs.Add(incommingFrog);
                        break;

                    case "Jump":
                        string commingFrog = commandArgs[1];
                        int indextoJumpAt = int.Parse(commandArgs[2]);
                        if (indextoJumpAt >= 0 && indextoJumpAt <= frogs.Count)
                        {
                            frogs.Insert(indextoJumpAt, commingFrog);
                        }
                        break;

                    case "Dive":
                        int indextoRemove = int.Parse(commandArgs[1]);
                        if (indextoRemove >= 0 && indextoRemove <= frogs.Count)
                        {
                            frogs.RemoveAt(indextoRemove);
                        }
                        break;

                    case "First":
                        int countToPrint = int.Parse(commandArgs[1]);
                        if (countToPrint > frogs.Count)
                        {
                            Console.WriteLine(string.Join(" ", frogs));
                        }
                        else
                        {
                            for (int i = 0; i <= countToPrint; i++)
                            {
        //////////////////////////////////////////////////////////////////////////////////////////////////
                                Console.Write(frogs[i]+" ");
                            }
                        }
                        break;

                    case "Last":
                        int countToPrintLAST = int.Parse(commandArgs[1]);
                        if (countToPrintLAST > frogs.Count)
                        {
                            Console.WriteLine(string.Join(" ", frogs));
                        }
                        else
                        {
                            for (int i = frogs.Count - countToPrintLAST; i < frogs.Count; i++)
                            {
                                Console.Write(frogs[i] + " ");
                            }
                        }
                        break;

                }

                commandArgs = Console.ReadLine().Split(' ').ToArray();
            }

            if (commandArgs[0] == "Print")
            {
                if (commandArgs[1] == "Normal")
                {
                    Console.WriteLine($"Frogs: {string.Join(" ",frogs)}");
                }
                else if (commandArgs[1] == "Reversed")
                {
                    frogs.Reverse();
                    Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
                }
            }
        }
    }
}
