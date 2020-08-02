﻿using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int cureent = numbers[i];
                if (cureent % 2==0)
                {
                    sum += cureent;
                }
            }
            Console.WriteLine(sum);

        }
    }
}
