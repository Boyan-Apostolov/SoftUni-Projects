using System;
using System.Linq;
using System.Collections.Generic;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }

            Analyze(jaggedArray);
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandInfor = Console.ReadLine().Split();
                int targetRow = int.Parse(commandInfor[1]);
                int targetCol = int.Parse(commandInfor[2]);
                int value = int.Parse(commandInfor[3]);

                if (!IsInside(jaggedArray,targetRow,targetCol))
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (commandInfor[0] == "Add")
                {
                    jaggedArray[targetRow][targetCol] += value;
                }
                else
                {
                    jaggedArray[targetRow][targetCol] -= value;
                }
                command = Console.ReadLine();
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool IsInside(double[][] jaggedArray, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < jaggedArray.Length && targetCol >= 0 && targetCol < jaggedArray[targetRow].Length;
        }

        private static void Analyze(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row+1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }
        }
    }
}
