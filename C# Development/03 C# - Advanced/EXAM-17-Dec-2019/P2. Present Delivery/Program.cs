using System;
using System.Linq;
using System.Collections.Generic;
namespace P2._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPresents = int.Parse(Console.ReadLine());
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            string[,] matrix = new string[sizeOfMatrix, sizeOfMatrix];
            int playerRow = 0;
            int playerCol = 0;
            //Initialize Matrix
            List<string> list = new List<string>();
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                string[] rowValues = Console.ReadLine().Split(" ").ToArray();
                
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (matrix[row, col] == "S")
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                }
            }

            int happyKids = 0;



            string direction = Console.ReadLine();

            while (true)
            {
                if (countOfPresents == 0 || direction == "Christmas morning")
                {
                    break;
                }

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

                if (matrix[playerNewRow, playerNewCol] == "X") //Bad
                {
                    matrix[playerNewRow, playerNewCol] = "S";
                    matrix[playerRow, playerCol] = "-";
                    playerRow = playerNewRow;
                    playerCol = playerNewCol;
                } //Bad boi
                else if (matrix[playerNewRow, playerNewCol] == "V") //Good
                {
                    matrix[playerNewRow, playerNewCol] = "S";
                    countOfPresents--;
                    happyKids++;
                    matrix[playerRow, playerCol] = "-";
                    playerRow = playerNewRow;
                    playerCol = playerNewCol;
                } //Good boi
                else if (matrix[playerNewRow, playerNewCol] == "-") //Noone
                {
                    matrix[playerNewRow, playerNewCol] = "S";
                    matrix[playerRow, playerCol] = "-";
                    playerRow = playerNewRow;
                    playerCol = playerNewCol;
                } //Noone
                else if (matrix[playerNewRow, playerNewCol] == "C")
                {
                    matrix[playerNewRow, playerNewCol] = "S";
                    matrix[playerRow, playerCol] = "-";
                    playerRow = playerNewRow;
                    playerCol = playerNewCol;

                    if (matrix[playerNewRow - 1, playerNewCol] == "V")
                    {
                        countOfPresents--;
                        matrix[playerNewRow - 1, playerNewCol] = "-";
                    }
                    if (matrix[playerNewRow + 1, playerNewCol] == "V")
                    {
                        countOfPresents--;
                        matrix[playerNewRow + 1, playerNewCol] = "-";
                    }
                    if (matrix[playerNewRow, playerNewCol + 1] == "V")
                    {
                        countOfPresents--;
                        matrix[playerNewRow, playerNewCol + 1] = "-";
                    }
                    if (matrix[playerNewRow, playerNewCol - 1] == "V")
                    {
                        countOfPresents--;
                        matrix[playerNewRow, playerNewCol - 1] = "-";
                    }

                    if (matrix[playerNewRow - 1, playerNewCol] == "X")
                    {
                        countOfPresents--;
                        matrix[playerNewRow - 1, playerNewCol] = "-";
                    }
                    if (matrix[playerNewRow + 1, playerNewCol] == "X")
                    {
                        countOfPresents--;
                        matrix[playerNewRow + 1, playerNewCol] = "-";
                    }
                    if (matrix[playerNewRow, playerNewCol + 1] == "X")
                    {
                        countOfPresents--;
                        matrix[playerNewRow, playerNewCol + 1] = "-";
                    }
                    if (matrix[playerNewRow, playerNewCol - 1] == "X")
                    {
                        countOfPresents--;
                        matrix[playerNewRow, playerNewCol - 1] = "-";
                    }
                } // Cookie
                if (countOfPresents == 0 || direction == "Christmas morning")
                {
                    break;
                }
                direction = Console.ReadLine();
            }

            if (countOfPresents == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            PrintMatrix(matrix);

            int unhappyKids = 0;
            foreach (var kid in matrix)
            {
                if (kid == "V")
                {
                    unhappyKids++;
                }
            }

            if (unhappyKids == 0)
            {
                Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {unhappyKids} nice kid/s.");
            }
        }

        private static void InitializeMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+" ");
                }
                Console.WriteLine();
            }
        }

    }
}
