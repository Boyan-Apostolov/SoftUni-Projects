using System;
using System.Linq;
namespace Miner
{
    class Program
    {
        static char[,] matrix;
        static int minorRow;
        static int minorCol;
        static int coals;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split();

            matrix = new char[size, size];
            PopulateMatrix();

            foreach (var currentDirection in directions)
            {
                switch (currentDirection)
                {
                    case "left":
                        Move(0, -1);
                        break;

                    case "right":
                        Move(0, 1);
                        break;

                    case "up":
                        Move(-1, 0);
                        break;

                    case "down":
                        Move(1, 0);
                        break;
                }
            }

            Console.WriteLine($"{coals} coals left. ({minorRow}, {minorCol})");
        }

        private static void Move(int row, int col)
        {
            if (IsInside(minorRow + row, minorCol + col))
            {
                minorRow += row;
                minorCol += col;

                if (matrix[minorRow, minorCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minorRow}, {minorCol})");
                    Environment.Exit(0);
                }

                if (matrix[minorRow, minorCol] == 'c')
                {
                    coals--;
                    matrix[minorRow, minorCol] = '*';
                    if (coals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minorRow}, {minorCol})");
                        Environment.Exit(0);
                    }
                }


            }
        }

        private static void PopulateMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 's')
                    {
                        minorRow = row;
                        minorCol = col;
                    }

                    if (matrix[row, col] == 'c')
                    {
                        coals++;
                    }
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
