using System;
using System.Collections.Generic;
using System.Linq;
namespace P02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];
            bool isOver = false;
            int playerOneRow = 0;
            int playerOneCol = 0;

            int playerTwoRow = 0;
            int playerTwoCol = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerOneCol = col;
                        playerOneRow = row;
                    }
                    else if (matrix[row, col] == 's')
                    {
                        playerTwoRow = row;
                        playerTwoCol = col;
                    }

                }
            }

            while (!isOver)
            {
                int playerOneNewRow = playerOneRow;
                int playerOneNewCol = playerOneCol;

                int playerTwoNewRow = playerTwoRow;
                int playerTwoNewCol = playerTwoCol;

                string[] directions = Console.ReadLine().Split().ToArray();

                string dir1 = directions[0];
                string dir2 = directions[1];

                switch (dir1)
                {
                    case "up":
                        playerOneNewRow--;
                        break;
                    case "down":
                        playerOneNewRow++;
                        break;
                    case "left":
                        playerOneNewCol--;
                        break;
                    case "right":
                        playerOneNewCol++;
                        break;
                }  //P1 Move

                switch (dir2)
                {
                    case "up":
                        playerTwoNewRow--;
                        break;
                    case "down":
                        playerTwoNewRow++;
                        break;
                    case "left":
                        playerTwoNewCol--;
                        break;
                    case "right":
                        playerTwoNewCol++;
                        break;
                } //P2 Move

                if (playerOneNewRow >= 0 && playerOneNewRow < matrix.GetLength(0) && playerOneNewCol >= 0 && playerOneNewCol < matrix.GetLength(0))
                {//If P1 is IN
                    if (matrix[playerOneNewRow, playerOneNewCol] == '*')
                    {
                        matrix[playerOneNewRow, playerOneNewCol] = 'f';
                        matrix[playerOneRow, playerOneCol] = 'f';
                        playerOneRow = playerOneNewRow;
                        playerOneCol = playerOneNewCol;
                    }
                    else if (matrix[playerOneNewRow, playerOneNewCol] == 's')
                    {
                        isOver = true;
                        matrix[playerOneNewRow, playerOneNewCol] = 'x';
                        
                    }
                }
                else
                {//If P1 is OUT

                }
                if (isOver)
                {
                    break;
                }
                if (playerTwoRow >= 0 && playerTwoRow < matrix.GetLength(0) && playerTwoNewCol >= 0 && playerTwoNewCol < matrix.GetLength(0))
                {//If P2 is IN
                    if (matrix[playerTwoNewRow, playerTwoNewCol] == '*')
                    {
                        matrix[playerTwoNewRow, playerTwoNewCol] = 's';
                        matrix[playerTwoRow, playerTwoCol] = 's';
                        playerTwoRow = playerTwoNewRow;
                        playerTwoCol = playerTwoNewCol;
                    }
                    else if (matrix[playerTwoNewRow, playerTwoNewCol] == 'f')
                    {
                        isOver = true;
                        matrix[playerTwoNewRow, playerTwoNewCol] = 'x';
                        
                    }
                }
                else
                {//If P2 is OUT

                }

            }

            PrintMatrix(matrix);

            static void PrintMatrix(char[,] matrix)
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
}
