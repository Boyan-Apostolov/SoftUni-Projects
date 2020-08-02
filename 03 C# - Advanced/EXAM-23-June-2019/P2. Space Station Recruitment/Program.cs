using System;
using System.Collections.Generic;
using System.Linq;
namespace P2._Space_Station_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];

            int playerRow = 0;
            int playerCol = 0;

            int blackHoleOneRow=-1;
            int blackHoleOneCol=-1;

            int blackHoleTwoRow=-1;
            int blackHoleTwoCol=-1;

            int starPower = 0;
            bool isVoid = false;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (matrix[row, col] == 'S')
                    {
                        playerCol = col;
                        playerRow = row;
                    }

                    if (matrix[row, col] == 'O')
                    {
                        if (blackHoleOneRow != -1)
                        {
                            blackHoleTwoCol = col;
                            blackHoleTwoRow = row;
                        }
                        else
                        {
                            blackHoleOneCol = col;
                            blackHoleOneRow = row;
                        }


                    }
                }
            }

            string direction = Console.ReadLine();
            while (starPower < 50 && !isVoid)
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
                    if (Char.IsDigit(matrix[playerNewRow, playerNewCol]))
                    {
                        int power = int.Parse(matrix[playerNewRow, playerNewCol].ToString());
                        starPower += power;
                        matrix[playerNewRow, playerNewCol] = 'S';
                        matrix[playerRow, playerCol] = '-';
                        playerRow = playerNewRow;
                        playerCol = playerNewCol;

                    }
                    else if (playerNewRow == blackHoleOneRow && playerNewCol == blackHoleOneCol)
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[blackHoleOneRow, blackHoleOneCol] = '-';
                        matrix[blackHoleTwoRow, blackHoleTwoCol] = 'S';
                        playerRow = blackHoleTwoRow;
                        playerCol = blackHoleTwoCol;
                    }
                    else if (playerNewRow == blackHoleTwoRow && playerNewCol == blackHoleTwoCol)
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[blackHoleTwoRow, blackHoleTwoCol] = '-';
                        matrix[blackHoleOneRow, blackHoleOneCol] = 'S';
                        playerRow = blackHoleOneRow;
                        playerCol = blackHoleOneCol;
                    }
                    else
                    {
                        matrix[playerNewRow, playerNewCol] = 'S';
                        matrix[playerRow, playerCol] = '-';
                        playerRow = playerNewRow;
                        playerCol = playerNewCol;
                    }
                    
                }
                else
                {
                    matrix[playerRow, playerCol] = '-';
                    isVoid = true;
                }

                if (starPower == 50 || isVoid)
                {
                    break;
                }

                direction = Console.ReadLine();
            }

            if (isVoid)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {starPower}");
                PrintMatrix(matrix);
            }

            if (starPower >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {starPower}");
                PrintMatrix(matrix);
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
