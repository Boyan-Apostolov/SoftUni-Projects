using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ParseArrayFromConsole(new[] { ' ', ',' });

            int rows = dimensions[0];
            int cols = dimensions[1];


            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = ParseArrayFromConsole(new[] { ' ' });

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow, maxCol + 1]} {matrix[maxRow + 1, maxCol] + 1}");
            Console.WriteLine(maxSum);
        }

        static int[] ParseArrayFromConsole(char[] splitSymbols)
        {
            return Console.ReadLine().
                Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
