using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P._02_BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] initialWord = Console.ReadLine().ToCharArray();

            Stack<char> word = new Stack<char>(initialWord);
            int n = int.Parse(Console.ReadLine());
            char[][] field = new char[n][];
            int playerRow = 0;
            int playerCol = 0;
            bool playerPossitionFound = false;
            if (!playerPossitionFound)
            {
                for (int row = 0; row < n; row++)
                {
                    char[] cirrentRow = Console.ReadLine().ToCharArray();
                    for (int col = 0; col < cirrentRow.Length; col++)
                    {
                        playerCol = col;
                        playerRow = row;
                        playerPossitionFound = true;
                    }
                    field[row] = cirrentRow; ;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;
                        char symbol = field[playerRow][playerCol];
                        if (char.IsLetterOrDigit(symbol))
                        {
                            word.Push(symbol);
                            field[playerRow][playerCol] = 'P';
                            field[playerRow + 1][playerCol] = '-';
                        }
                    }
                    else
                    {
                        if (word.Count > 0) word.Pop();
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 < n)
                    {
                        playerRow--;
                        char symbol = field[playerRow][playerCol];
                        if (char.IsLetterOrDigit(symbol))
                        {
                            word.Push(symbol);
                            field[playerRow][playerCol] = 'P';
                            field[playerRow - 1][playerCol] = '-';
                        }
                    }
                    else
                    {
                        if (word.Count > 0) word.Pop();
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                        char symbol = field[playerRow][playerCol];
                        if (char.IsLetterOrDigit(symbol))
                        {
                            word.Push(symbol);
                        }

                        field[playerRow][playerCol] = 'P';
                        field[playerRow][playerCol + 1] = '-';
                    }
                    else
                    {
                        if (word.Count > 0) word.Pop();
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 < n)
                    {
                        playerCol++;
                        char symbol = field[playerRow][playerCol];
                        if (char.IsLetterOrDigit(symbol))
                        {
                            word.Push(symbol);
                        }

                        field[playerRow][playerCol] = 'P';
                        field[playerRow][playerCol - 1] = '-';
                    }
                    else
                    {
                        if (word.Count > 0) word.Pop();
                    }

                    field[playerRow][playerCol] = 'P';
                    field[playerRow][playerCol + 1] = '-';
                }
                else
                {
                    if (word.Count > 0) word.Pop();
                }
            }

            Console.WriteLine(string.Join(", ", word.Reverse()));

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }

                Console.WriteLine();
            }
        }

    }
}

