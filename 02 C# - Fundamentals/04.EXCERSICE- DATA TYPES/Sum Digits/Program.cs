﻿using System;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int digit = num[i]-48;
                sum += digit;
            }
            Console.WriteLine(sum);
        }
    }
}
