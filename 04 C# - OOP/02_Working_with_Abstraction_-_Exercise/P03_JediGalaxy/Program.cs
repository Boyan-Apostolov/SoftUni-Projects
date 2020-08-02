using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        private static int[,] matrix;
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int r = dimensions[0];
            int c = dimensions[1];
            InitializeField(r, c);
            
            string command = Console.ReadLine();
            long sum = 0;

            while (command != "Let the Force be with you")
            {
                sum = ProcessInfo(command, sum);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static long ProcessInfo(string command, long sum)
        {
            int[] ivoCoordinates, evilCoordinates;
            InitializePlayers(command, out ivoCoordinates, out evilCoordinates);

            MoveEvil(evilCoordinates);
            int ivoRow, ivoCol;
            Start(ivoCoordinates, out ivoRow, out ivoCol);
            MoveIvo(ref sum, ref ivoRow, ref ivoCol);
            return sum;
        }

        private static void MoveIvo(ref long sum, ref int ivoRow, ref int ivoCol)
        {
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }

        private static void Start(int[] ivoCoordinates, out int ivoRow, out int ivoCol)
        {
            ivoRow = ivoCoordinates[0];
            ivoCol = ivoCoordinates[1];
        }

        private static void InitializePlayers(string command, out int[] ivoCoordinates, out int[] evilCoordinates)
        {
            ivoCoordinates = command.
                                Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            evilCoordinates = Console.ReadLine()
.Split(new string[] { " " }, StringSplitOptions
.RemoveEmptyEntries)
.Select(int.Parse)
.ToArray();
        }

        private static void MoveEvil(int[] evilCoordinates)
        {
            int evilRow = evilCoordinates[0];
            int evilCol = evilCoordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static void InitializeField(int r, int c)
        {
            matrix = new int[r, c];

            int value = 0;

            for (int row = 0; row < r; row++)
            {
                for (int col = 0; col < c; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}
