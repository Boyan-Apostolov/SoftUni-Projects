using System;
using System.Collections.Generic;
using System.Linq;
namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = ReadIntegerMatrix(n, n);

            //for (int row = 0; row < n; row++)
            //{
            //    int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //    for (int col = 0; col < n; col++)
            //    {
            //        matrix[row, col] = rowValues[col];
            //    }
            //}

            int diagonalOne = 0;

            int diagonalTwo = 0;

            for (int row = 0; row < n; row++)
            {
                diagonalOne += matrix[row, row];
                diagonalTwo += matrix[row, n - row - 1];
            }

            Console.WriteLine(Math.Abs(diagonalOne - diagonalTwo));
        }

        private static int[,] ReadIntegerMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
            return matrix;
        }
    }
}
