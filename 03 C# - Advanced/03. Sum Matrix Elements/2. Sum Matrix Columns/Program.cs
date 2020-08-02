using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ParseArrayFromConsole(new[] {' ',','});

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

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sumOfCurrentColumn = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumOfCurrentColumn += matrix[row, col];
                }
                Console.WriteLine(sumOfCurrentColumn);
            }
        }

        //static void SomeMEthood(params int[] numbers)
        //{
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        Console.WriteLine(numbers[i]);
        //    }
        //}

        static int[] ParseArrayFromConsole(char[] splitSymbols)
        {
            return Console.ReadLine().
                Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
