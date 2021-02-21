using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] els = Console.ReadLine().Split();

                foreach (var el in els)
                {
                    elements.Add(el);
                }
            }

            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
