using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] pascalTrieangle = new int[rows][];

            if (rows >= 1)
            {
                pascalTrieangle[0] = new int[] { 1 };
            }

            if (rows>=2)
            {
                pascalTrieangle[1] = new[] { 1,1 };
            }

            for (int row = 2; row < rows; row++)
            {
                pascalTrieangle[row] = new int [ row + 1 ];
                pascalTrieangle[row][0] = 1;

                pascalTrieangle[row][row] = 1;

                for (int col = 1; col < row; col++)
                {
                    pascalTrieangle[row][col] = pascalTrieangle[row - 1][col] + pascalTrieangle[row - 1][col - 1];
                }
            }

            foreach (var currentRow in pascalTrieangle)
            {
                Console.WriteLine(string.Join(" ",currentRow));
            }

            

        }
    }
}
