using System;
using System.Linq;
using System.Collections.Generic;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] array = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                array[row] = new int[currentRow.Length];

                array[row] = currentRow;
            }

            while (true)
            {
                string command = Console.ReadLine().ToLower();

                if (command == "end")
                {
                    foreach (int[] currentRow in array)
                    {
                        Console.WriteLine(string.Join(" ",currentRow));
                    }
                    break;
                }




                string[] commandPart = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(commandPart[1]);
                int col = int.Parse(commandPart[2]);
                int value = int.Parse(commandPart[3]);

                if (row < 0 || row >= rows || col < 0 || col >= array[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (commandPart[0] == "add")
                {
                    array[row][col] += value;
                }
                else if (commandPart[0] == "subtract")
                {
                    array[row][col] -= value;

                }
            }
        }
    }
}
