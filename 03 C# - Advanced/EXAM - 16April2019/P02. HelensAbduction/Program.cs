using System;

namespace P02._HelensAbduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];
            int playerRow = 0;
            int playerCol = 0;

            int playerNewRow = 0;
            int playerNewCol = 0;

            bool isWon = false;
            bool isDead = false;
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
            playerNewRow = playerRow;
            playerNewCol = playerCol;

            while (energy > 0)
            {
                if (isWon)
                {
                    break;
                }
                if (isDead)
                {
                    break;
                }
                string[] cmdArgs = Console.ReadLine().Split();
                string direction = cmdArgs[0];
                int spawnRow = int.Parse(cmdArgs[1]);
                int spawnCol = int.Parse(cmdArgs[2]);
                matrix[spawnRow, spawnCol] = 'S';

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
                    energy--;
                    
                    if (matrix[playerNewRow, playerNewCol] == '-')
                    {
                        matrix[playerNewRow, playerNewCol] = 'P';
                        matrix[playerRow, playerCol] = '-';
                        playerRow = playerNewRow;
                        playerCol = playerNewCol;

                    }
                    else if (matrix[playerNewRow, playerNewCol] == 'S')
                    {
                        energy -= 2;
                        if (energy > 0)
                        {
                            matrix[playerNewRow, playerNewCol] = 'P';
                            matrix[playerRow, playerCol] = '-';
                            playerRow = playerNewRow;
                            playerCol = playerNewCol;
                        }
                        else
                        {
                            matrix[playerNewRow, playerNewCol] = 'X';
                            matrix[playerRow, playerCol] = '-';
                            playerRow = playerNewRow;
                            playerCol = playerNewCol;
                            isDead = true;
                            break;
                        }
                    }
                    else if (matrix[playerNewRow, playerNewCol] == 'H')
                    {

                        matrix[playerNewRow, playerNewCol] = '-';
                        matrix[playerRow, playerCol] = '-';
                        isWon = true;
                        break;
                    }

                    if (energy <= 0)
                    {

                        matrix[playerNewRow, playerNewCol] = 'X';
                        playerRow = playerNewRow;
                        playerCol = playerNewCol;
                        isDead = true;
                        break;
                    }
                }
                else
                {
                    energy--;
                    playerNewRow = playerRow;
                    playerNewCol = playerCol;
                }
            }

            if (isDead)
            {
                Console.WriteLine($"Paris died at {playerRow};{playerCol}.");
                PrintMatrix(matrix);
            }

            if (isWon)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
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
