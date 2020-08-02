using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> field = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int[] tokens = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int bombNumber = tokens[0];
            int power = tokens[1];

            for (int i = 0; i < field.Count; i++)
            {
                int target = field[i];

                if (target == bombNumber)
                {
                    BombNumbers(field,power,i);
                }
            }

            int sum = field.Sum();
            Console.WriteLine(sum);


        }

        static void BombNumbers(List<int> field, int power, int i)
        {
            int start = Math.Max(0, i - power);
            int end = Math.Min(field.Count - 1, i + power);

            for (int j = start; j <= end; j++)
            {
                field[j] = 0;
            }
        }
    }
}
