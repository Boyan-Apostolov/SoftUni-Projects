using System;
using System.Linq;
using System.Collections.Generic;
namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersString = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string line = null;

            while (line != "End")
            {   line = Console.ReadLine();

                string[] lineParameters = line.Split();

                switch (lineParameters[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(lineParameters[1]);
                        numbersString.Add(numberToAdd);
                        break;

                    case "Insert":
                        int numberToInsert = int.Parse(lineParameters[1]);
                        int possitionToInsertAt = int.Parse(lineParameters[2]);
                        if (possitionToInsertAt >= 0 && possitionToInsertAt < numbersString.Count)
                        {
                            numbersString.Insert(possitionToInsertAt, numberToInsert);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;

                    case "Remove":
                        int indexToRemoveAt = int.Parse(lineParameters[1]);
                        if (indexToRemoveAt >= 0 && indexToRemoveAt < numbersString.Count)
                        {
                            numbersString.RemoveAt(indexToRemoveAt);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;

                    case "Shift":
                        if (lineParameters[1] == "left")
                        {
                            int shiftByLeft = int.Parse(lineParameters[2]);
                            for (int i = 0; i < shiftByLeft; i++)
                            {
                                int currentValue = numbersString[0];
                                numbersString.RemoveAt(0);
                                numbersString.Add(currentValue);
                            }
                        }
                        else if (lineParameters[1] == "right")
                        {
                            int shiftByRight = int.Parse(lineParameters[2]);
                            for (int i = 0; i < shiftByRight; i++)
                            {
                                int currentNumber = numbersString[numbersString.Count - 1];
                                numbersString.RemoveAt(numbersString.Count - 1);
                                numbersString.Insert(0, currentNumber);
                            }
                        }

                        break;


                }
                
            }
            Console.WriteLine(string.Join(" ",numbersString));
        }
    }
}
