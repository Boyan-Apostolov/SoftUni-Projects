using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02._Seashell_Treasure
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> collected = new List<char>();
            int stolen = 0;
            int size = int.Parse(Console.ReadLine());

            //Initialise Matrix
            char[][] matrix = new char[size][];
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[row] = new char[currentRow.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];
                }
            }

            string input = Console.ReadLine();
            while (input != "Sunset")
            {
                string[] splittedInput = input
                    .Split(" ");

                string command = splittedInput[0];
                int row = int.Parse(splittedInput[1]);
                int col = int.Parse(splittedInput[2]);

                if (command == "Collect")
                {
                    if (row >= 0 && row < size && col >= 0 && col < matrix[row].Length)
                    {
                        if (matrix[row][col] != '-')
                        {
                            collected.Add(matrix[row][col]);
                            matrix[row][col] = '-';
                        }
                    }
                } //Collect

                if (command == "Steal")
                {
                    string direction = splittedInput[3];

                    //Directions
                    if (row >= 0 && row < size && col >= 0 && col < matrix[row].Length)
                    {
                        if (direction == "down")
                        {
                            for (int i = row; i <= row + 3; i++)
                            {
                                if (i >= 0 && i < matrix.Length && col >= 0 && col < matrix[i].Length && matrix[i][col] != '-')
                                {
                                    stolen++;
                                    matrix[i][col] = '-';
                                }
                            }
                        }
                        else if (direction == "up")
                        {
                            for (int i = row; i >= row - 3; i--)
                            {
                                if (i >= 0 && i < matrix.Length && col >= 0 && col < matrix[i].Length && matrix[i][col] != '-')
                                {
                                    stolen++;
                                    matrix[i][col] = '-';
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = col; i <= matrix[row].Length; i++)
                            {
                                if (row >= 0 && row < matrix.Length && i >= 0 && i < matrix[row].Length && matrix[row][i] != '-')
                                {
                                    stolen++;
                                    matrix[row][i] = '-';
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = col; i >= col - 3; i--)
                            {
                                if (row >= 0 && row < matrix.Length && i >= 0 && i < matrix[row].Length && matrix[row][i] != '-')
                                {
                                    stolen++;
                                    matrix[row][i] = '-';
                                }
                            }
                        }
                    }
                } //Steal

                input = Console.ReadLine();
            }

            //Ouput Printing

            foreach (var ins in matrix)
            {
                Console.WriteLine(string.Join(" ", ins));
            }

            if (collected.Count != 0)
            {
                Console.Write($"Collected seashells: {collected.Count} -> ");
                Console.Write(string.Join(", ", collected));
                Console.WriteLine();
                Console.WriteLine($"Stolen seashells: { stolen}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collected.Count}");
                Console.WriteLine($"Stolen seashells: { stolen}");
            }
        }
    }
}
