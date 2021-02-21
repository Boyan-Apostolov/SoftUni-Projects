using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P2._Bookworm
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();
            StringBuilder finalString = new StringBuilder();
            finalString.Append(initialString);
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];

            // InitializeMatrix(matrix);

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                }
            }

            string direction = Console.ReadLine();
            while (direction != "end")
            {
                int playerNewRow = playerRow;
                int playerNewCol = playerCol;

                switch (direction)
                {
                    case "up":
                        playerNewRow--;
                        break;
                    case "down":
                        playerNewRow++;
                        break;
                    case "left":
                        playerNewCol--;
                        break;
                    case "right":
                        playerNewCol++;
                        break;
                }

                if (playerNewRow >= 0 && playerNewRow < matrix.GetLength(0) && playerNewCol >= 0 && playerNewCol < matrix.GetLength(0))
                {
                    if (Char.IsLetter(matrix[playerNewRow, playerNewCol]))
                    {
                        finalString.Append(matrix[playerNewRow, playerNewCol]);
                    }

                    matrix[playerNewRow, playerNewCol] = 'P';
                    matrix[playerRow, playerCol] = '-';
                    playerRow = playerNewRow;
                    playerCol = playerNewCol;

                }
                else
                {
                    finalString.Remove(finalString.Length - 1, 1);
                }

                direction = Console.ReadLine();
            }

            Console.WriteLine(finalString);
            PrintMatrix(matrix);
        }

        private static void InitializeMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
