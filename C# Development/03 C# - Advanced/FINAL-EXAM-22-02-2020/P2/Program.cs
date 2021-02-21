using System;
using System.Collections.Generic;
using System.Linq;
namespace P2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int maxCommands = int.Parse(Console.ReadLine());
            int countOfCommands = 0;
            bool isWon = false;
            bool isLost = false;
            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];

            int playerRow = 0;
            int playerCol = 0;

            int playerNewRow = 0;
            int playerNewCol = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                }
            }

            while (countOfCommands < maxCommands)
            {
                if (isWon)
                {
                    break;
                }

                if (isLost)
                {
                    break;
                }

                playerNewRow = playerRow;
                playerNewCol = playerCol;

                string direction = Console.ReadLine();

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
                countOfCommands++;
                if (playerNewRow >= 0 && playerNewRow < matrix.GetLength(0) && playerNewCol >= 0 && playerNewCol < matrix.GetLength(1))
                {
                    if (matrix[playerNewRow, playerNewCol] == 'F')  //F
                    {
                        isWon = true;
                        matrix[playerNewRow, playerNewCol] = 'f';
                        matrix[playerRow, playerCol] = '-';
                        playerRow = playerNewRow;
                        playerCol = playerNewCol;

                    }
                    else if (matrix[playerNewRow, playerNewCol] == 'B') //B
                    {
                        var com = direction;
                        int newCol = playerNewCol;
                        int newRow = playerNewRow;
                        switch (com)
                        {
                            case "up":
                                newRow--;
                                break;
                            case "down":
                                newRow++;
                                break;
                            case "left":
                                newCol--;
                                break;
                            case "right":
                                newCol++;
                                break;
                        }

                        if (newRow >= 0 && newRow < matrix.GetLength(0) && newCol >= 0 && newCol < matrix.GetLength(1))
                        {
                            if (newRow >= 0 && newRow < matrix.GetLength(0) && newCol >= 0 && newCol < matrix.GetLength(1))
                            {
                                if (matrix[newRow, newCol] == 'F')  //F
                                {
                                    isWon = true;
                                    matrix[newRow, newCol] = 'f';
                                    matrix[playerRow, playerCol] = '-';
                                    playerRow = playerNewRow;
                                    playerCol = playerNewCol;
                                    break;
                                }
                                else
                                {
                                    matrix[playerRow, playerCol] = '-';
                                    matrix[newRow, newCol] = 'f';
                                    playerRow = newRow;
                                    playerCol = newCol;
                                }

                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[newRow, newCol] = 'f';
                                playerRow = newRow;
                                playerCol = newCol;
                            }

                        }
                        else
                        {
                            //Error Test 9
                            if (newRow < 0)
                            {
                                playerNewRow = matrix.GetLength(0) - 1;
                            }
                            if (newCol < 0)
                            {
                                playerNewCol = matrix.GetLength(1) - 1;
                            }

                            if (newRow >= matrix.GetLength(0))
                            {
                                playerNewRow = 0;
                            }
                            if (newCol >= matrix.GetLength(0))
                            {
                                playerNewCol = 0;
                            }

                            if (matrix[playerNewRow, playerNewCol] == 'F')  //F
                            {
                                isWon = true;
                                matrix[playerNewRow, playerNewCol] = 'f';
                                matrix[playerRow, playerCol] = '-';
                                playerRow = playerNewRow;
                                playerCol = playerNewCol;
                                break;
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[playerNewRow, playerNewCol] = 'f';
                               
                            }

                            matrix[playerNewRow, playerNewCol] = 'f';
                            matrix[playerRow, playerCol] = '-';
                            playerRow = playerNewRow;
                            playerCol = playerNewCol;
                        }


                    }
                    else if (matrix[playerNewRow, playerNewCol] == 'T') //T
                    {
                        var com = direction;
                        int newCol = playerNewCol;
                        int newRow = playerNewRow;
                        switch (com)
                        {
                            case "up":
                                newRow++;
                                break;
                            case "down":
                                newRow--;
                                break;
                            case "left":
                                newCol++;
                                break;
                            case "right":
                                newCol--;
                                break;
                        }

                        matrix[newRow, newCol] = 'f';
                        matrix[playerRow, playerCol] = '-';
                        playerRow = newRow;
                        playerCol = newCol;
                    }
                    else
                    {
                        matrix[playerNewRow, playerNewCol] = 'f';
                        matrix[playerRow, playerCol] = '-';
                        playerRow = playerNewRow;
                        playerCol = playerNewCol;
                    }
                }
                else
                {
                    if (playerNewRow < 0)
                    {
                        playerNewRow = matrix.GetLength(0) - 1;
                    }
                    if (playerNewCol < 0)
                    {
                        playerNewCol = matrix.GetLength(1) - 1;
                    }

                    if (playerNewRow >= matrix.GetLength(0))
                    {
                        playerNewRow = 0;
                    }
                    if (playerNewCol >= matrix.GetLength(0))
                    {
                        playerNewCol = 0;
                    }



                    if (matrix[playerNewRow, playerNewCol] == 'F') //F
                    {
                        isWon = true;
                        matrix[playerNewRow, playerNewCol] = 'f';
                        matrix[playerRow, playerCol] = '-';
                        playerRow = playerNewRow;
                        playerCol = playerNewCol;

                    }
                    else if (matrix[playerNewRow, playerNewCol] == 'B') //B
                    {
                        var com = direction;
                        int newCol = playerNewCol;
                        int newRow = playerNewRow;
                        switch (com)
                        {
                            case "up":
                                newRow--;
                                break;
                            case "down":
                                newRow++;
                                break;
                            case "left":
                                newCol--;
                                break;
                            case "right":
                                newCol++;
                                break;
                        }

                        if (newRow >= 0 && newRow < matrix.GetLength(0) && newCol >= 0 && newCol < matrix.GetLength(1))
                        {
                            if (newRow >= 0 && newRow < matrix.GetLength(0) && newCol >= 0 && newCol < matrix.GetLength(1))
                            {
                                if (matrix[newRow, newCol] == 'F')  //F
                                {
                                    isWon = true;
                                    matrix[playerNewRow, playerNewCol] = 'f';
                                    matrix[playerRow, playerCol] = '-';
                                    playerRow = playerNewRow;
                                    playerCol = playerNewCol;

                                }

                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[newRow, newCol] = 'f';
                                playerRow = newRow;
                                playerCol = newCol;
                            }


                        }
                        else
                        {
                            //Error Test 9
                            if (newRow < 0)
                            {
                                playerNewRow = matrix.GetLength(0) - 1;
                            }
                            if (newCol < 0)
                            {
                                playerNewCol = matrix.GetLength(1) - 1;
                            }

                            if (newRow >= matrix.GetLength(0))
                            {
                                playerNewRow = 0;
                            }
                            if (newCol >= matrix.GetLength(0))
                            {
                                playerNewCol = 0;
                            }

                            if (newRow >= 0 && newRow < matrix.GetLength(0) && newCol >= 0 && newCol < matrix.GetLength(1))
                            {
                                if (matrix[newRow, newCol] == 'F')  //F
                                {
                                    isWon = true;
                                    matrix[newRow, newCol] = 'f';
                                    matrix[playerRow, playerCol] = '-';
                                    playerRow = playerNewRow;
                                    playerCol = playerNewCol;

                                }
                                else
                                {
                                    matrix[playerRow, playerCol] = '-';
                                    matrix[newRow, newCol] = 'f';
                                    playerRow = newRow;
                                    playerCol = newCol;
                                }

                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[newRow, newCol] = 'f';
                                playerRow = newRow;
                                playerCol = newCol;
                            }
                        }
                    }
                    else if (matrix[playerNewRow, playerNewCol] == 'T') //T
                    {
                        var com = direction;
                        int newCol = playerNewCol;
                        int newRow = playerNewRow;
                        switch (com)
                        {
                            case "up":
                                newRow++;
                                break;
                            case "down":
                                newRow--;
                                break;
                            case "left":
                                newCol++;
                                break;
                            case "right":
                                newCol--;
                                break;
                        }

                        matrix[newRow, newCol] = 'f';
                        matrix[playerRow, playerCol] = '-';
                        playerRow = newRow;
                        playerCol = newCol;
                    }
                    else
                    {
                        matrix[playerNewRow, playerNewCol] = 'f';
                        matrix[playerRow, playerCol] = '-';
                        playerRow = playerNewRow;
                        playerCol = playerNewCol;
                    }
                }
                if (!(countOfCommands < maxCommands))
                {
                    isLost = true;
                    break;
                }
            }

            if (isWon)
            {
                Console.WriteLine("Player won!");
                PrintMatrix(matrix);
            }
            else
            {
                Console.WriteLine("Player lost!");
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
