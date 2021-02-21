using System;
using System.Linq;
using System.Collections.Generic;
namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            bool isWon = false;
            bool isDead = false;
            foreach (var direction in directions)
            {
                int playerNewRow = playerRow;
                int playerNewCol = playerCol;

                switch (direction)
                {
                    case 'U':
                        playerNewRow--;
                        break;
                    case 'D':
                        playerNewRow++;
                        break;
                    case 'L':
                        playerNewCol--;
                        break;
                    case 'R':
                        playerNewCol++;
                        break;
                }

                isWon = IsWon(matrix, playerNewRow, playerNewCol);

                if (!isWon)
                {
                    isDead = IsSymbol(matrix, 'B', playerNewRow, playerNewCol);
                    if (!isDead)
                    {
                        matrix[playerNewRow, playerNewCol] = 'P';
                    }

                    playerRow = playerNewRow;
                    playerCol = playerNewCol;
                    matrix[playerRow, playerCol] = '.';
                }
                else
                {
                    matrix[playerRow, playerCol] = '.';
                }

                List<int> bunnyCoords = new List<int>();

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunnyCoords.Add(row);
                            bunnyCoords.Add(col);
                        }
                    }
                }

                for (int i = 0; i < bunnyCoords.Count; i += 2)
                {
                    int bunnyRow = bunnyCoords[i];
                    int bunnyCol = bunnyCoords[i + 1];

                    SpreadBunny(matrix, bunnyRow, bunnyCol);

                }

                isDead = IsSymbol(matrix, 'B', playerRow, playerCol);

                if (isWon || isDead)
                {
                    break;
                }
            }

            PrintMatrix(matrix);

            if (isWon = true)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static void SpreadBunny(char[,] matrix, int bunnyRow, int bunnyCol)
        {
            if (bunnyRow - 1 >= 0)
            {
                matrix[bunnyRow - 1, bunnyCol] = 'B';
            }

            if (bunnyRow + 1 < matrix.GetLength(0))
            {
                matrix[bunnyRow + 1, bunnyCol] = 'B';
            }

            if (bunnyCol - 1 >= 0)
            {
                matrix[bunnyRow, bunnyCol - 1] = 'B';
            }

            if (bunnyRow + 1 < matrix.GetLength(1))
            {
                matrix[bunnyRow, bunnyCol + 1] = 'B';
            }



        }

        private static bool IsSymbol(char[,] matrix, char symbol, int row, int col)
        {
            bool isSymbol = false;
            if (matrix[row, col] == symbol)
            {
                isSymbol = true;
            }
            return isSymbol;
        }

        private static bool IsWon(char[,] matrix, int row, int col)
        {
            bool isWon = true;

            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(0))
            {
                isWon = false;
            }
            return isWon;
        }

        static bool IsValidCell(string[,] matrix, int row, int col)
        {
            bool isValid = false;
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                isValid = true;
            }
            return isValid;
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
            return matrix;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.WriteLine(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
