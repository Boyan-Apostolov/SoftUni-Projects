using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 4

            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int totalRows = dimensions[0];
            int totalCols = dimensions[1];

            int[,] matrix = new int[totalRows, totalCols];

            InitializeMatrix(matrix);

            int maxNUmber = int.MinValue;

            int targetRow = 0;
            int targetCol = 0;

            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    //0 1 2
                    //3 4 5
                    //6 7 8
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxNUmber)
                    {
                        maxNUmber = currentSum;
                        targetCol = col;
                        targetRow = row;
                    }
                    
                }
            }
            Console.WriteLine($"Sum = {maxNUmber}");

            for (int row = targetRow; row <= targetRow+2; row++)
            {
                for (int col = targetCol; col <= targetCol+2; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }

        private static void InitializeMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}

