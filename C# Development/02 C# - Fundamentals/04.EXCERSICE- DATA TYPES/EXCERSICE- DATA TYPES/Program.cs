﻿using System;

namespace EXCERSICE__DATA_TYPES
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int n4 = int.Parse(Console.ReadLine());
            int result = (n1 + n2) / n3 * n4;
            Console.WriteLine(result);

        }
    }
}
