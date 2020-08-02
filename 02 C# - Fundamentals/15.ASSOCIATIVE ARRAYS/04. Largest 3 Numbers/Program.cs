using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var sortedNumbers = numbers.OrderByDescending(n => n).ToArray();
            int count = numbers.Length >= 3 ? 3 : numbers.Length;
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{sortedNumbers[i]} ");
            }
        }
    }
}
