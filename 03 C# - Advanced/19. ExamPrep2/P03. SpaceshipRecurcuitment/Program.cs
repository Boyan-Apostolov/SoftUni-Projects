using System;
using System.ComponentModel.Design;

namespace P03._SpaceshipRecurcuitment
{
    class Program
    {
        private static char[][] galaxy;
        private static int playerrow;
        private static int playercol;
        private const int MIN_POWER_NEEDED = 50;
        private static int collectedEnergy;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            galaxy = new char[n][];
            bool found = false;
            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                if (!found)
                {
                    for (int col = 0; col < currentRow.Length; col++)
                    {
                        if (currentRow[col] == 'S')
                        {
                            playercol = col;
                            playerrow = row;
                            found = true;
                        }
                    }
                }

                galaxy[row] = currentRow;
            } //Fill

            while (collectedEnergy < MIN_POWER_NEEDED)
            {
                string direction = Console.ReadLine();
                if (direction == "up")
                {
                    if (playercol - 1 >= 0)
                    {
                        int nextRow = playerrow - 1;
                        int nextcol = playercol;
                        char nextSymbol = galaxy[nextRow][nextcol];
                        if (Char.IsDigit(nextSymbol))
                        {
                            int starEnergy = (int)nextSymbol - 48;
                            collectedEnergy += starEnergy;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if (direction == "down")
                {
                    
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            char iterSymbol = galaxy[row][col];
                        }
                    }
                }
                else if (direction == "left")
                {

                }
                else if (direction == "right")
                {

                }
            }
        }
    }
}
