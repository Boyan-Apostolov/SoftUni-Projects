using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
