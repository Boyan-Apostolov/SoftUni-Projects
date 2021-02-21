










/*
 * 
 * 
 * GIVES 40 IN JUDJE
 * 
 * 
 */










using System;
using System.Linq;
using System.Collections.Generic;
namespace _7._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersString = Console.ReadLine().Split(' ').Select(int.Parse).ToList();


            var line = string.Empty;

            while (line != "end")
            {
                line = Console.ReadLine();

                string[] lineParameters = line.Split();

                switch (lineParameters[0])
                {
                    //case "Add":
                        //int numberToAdd = int.Parse(lineParameters[1]);
                        //numbersString.Add(numberToAdd);
                        //break;
                    //To do
                  //  case "Remove":
                       // int numberToRemove = int.Parse(lineParameters[1]);
                       // numbersString.Remove(numberToRemove);
                       // break;
                  //  case "RemoveAt":
                      //  int indexToRemoveAt = int.Parse(lineParameters[1]);
                      //  numbersString.RemoveAt(indexToRemoveAt);
                      //  break;
                  //  case "Insert":
                       // int numberToInsert = int.Parse(lineParameters[1]);
                      //  int indexToInserAt = int.Parse(lineParameters[2]);
                        //numbersString.Insert(indexToInserAt, numberToInsert);
                        //break;
                    case "Contains":
                        int containingNumber = int.Parse(lineParameters[1]);
                        if (numbersString.Contains(containingNumber))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        Console.WriteLine();
                        break;
                    case "PrintEven":
                        for (int i = 0; i < numbersString.Count; i++)
                        {
                            if (numbersString[i] % 2 == 0)
                            {
                                Console.Write(numbersString[i]+" ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "PrintOdd":
                        for (int i = 0; i < numbersString.Count; i++)
                        {
                            if (numbersString[i] % 2 != 0)
                            {
                                Console.Write(numbersString[i] + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "GetSum":
                        Console.WriteLine(numbersString.Sum());
                        
                        break;
                    case "Filter":
                        string condition = lineParameters[1];
                        int filterNumber = int.Parse(lineParameters[2]);
                        foreach (var item in numbersString)
                                {
                                    switch (condition)
                                    {
                                        case "<":

                                            if (item < filterNumber)
                                            {
                                                Console.Write(item + " ");
                                            }

                                            break;
                                        case ">":
                                            if (item > filterNumber)
                                            {
                                                Console.Write(item + " ");
                                            }
                                            break;
                                        case ">=":
                                            if (item >= filterNumber)
                                            {
                                                Console.Write(item + " ");
                                            }

                                            break;
                                        case "<=":
                                            if (item <= filterNumber)
                                            {
                                                Console.Write(item + " ");
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                        Console.WriteLine();
                        break;
                }


            }

            

        }
    }
}
