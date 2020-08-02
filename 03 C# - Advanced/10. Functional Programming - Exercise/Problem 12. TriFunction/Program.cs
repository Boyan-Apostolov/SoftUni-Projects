using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().ToArray();

            foreach (var name in names)
            {
                int sum = 0;
                foreach (char ch in name)
                {
                    sum += ch;
                }

                if (sum >= count)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
