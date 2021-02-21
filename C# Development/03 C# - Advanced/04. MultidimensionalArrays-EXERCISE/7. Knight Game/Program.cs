using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] chestBoard = new char[size, size];

            for (int row = 0; row < chestBoard.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < chestBoard.GetLength(1); col++)
                {
                    chestBoard[row, col] = input[col];
                }
            }

            int killerRow = 0;
            int killerCol = 0;
            int knightsCount = 0;
            while (true)
            {

                int maxAttacks = 0;
                for (int row = 0; row < chestBoard.GetLength(0); row++)
                {

                    for (int col = 0; col < chestBoard.GetLength(1); col++)
                    {
                        int currentKnightsAttacks = 0;

                        if (chestBoard[row, col] == 'K')
                        {
                            if (IsInside(chestBoard, row - 2, col + 1) && chestBoard[row - 2, col + 1] == 'K')
                            {
                                currentKnightsAttacks++;
                            }

                            if (IsInside(chestBoard, row - 2, col - 1) && chestBoard[row - 2, col - 1] == 'K')
                            {
                                currentKnightsAttacks++;
                            }

                            if (IsInside(chestBoard, row - 1, col + 2) && chestBoard[row - 1, col + 2] == 'K')
                            {
                                currentKnightsAttacks++;
                            }

                            if (IsInside(chestBoard, row - 1, col - 2) && chestBoard[row - 1, col - 2] == 'K')
                            {
                                currentKnightsAttacks++;
                            }

                            if (IsInside(chestBoard, row + 1, col + 2) && chestBoard[row + 1, col + 2] == 'K')
                            {
                                currentKnightsAttacks++;
                            }

                            if (IsInside(chestBoard, row + 1, col - 2) && chestBoard[row + 1, col - 2] == 'K')
                            {
                                currentKnightsAttacks++;
                            }

                            if (IsInside(chestBoard, row + 2, col + 1) && chestBoard[row + 2, col + 1] == 'K')
                            {
                                currentKnightsAttacks++;
                            }

                            if (IsInside(chestBoard, row + 2, col - 1) && chestBoard[row + 2, col - 1] == 'K')
                            {
                                currentKnightsAttacks++;
                            }
                        }

                        if (currentKnightsAttacks > maxAttacks)
                        {
                            maxAttacks = currentKnightsAttacks;
                            killerRow = row;
                            killerCol = col;
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    chestBoard[killerRow, killerCol] = '0';
                    knightsCount++;
                }
                else
                {
                    Console.WriteLine(knightsCount);
                    break;
                }
            }
        }

        private static bool IsInside(char[,] chestBoard, int row, int col)
        {
            return row >= 0 && row < chestBoard.GetLength(0) && col >= 0 && col < chestBoard.GetLength(1);
        }
    }
}
