using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {

            int end = int.Parse(Console.ReadLine());

            List<int> divisors = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> divisable = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                var isDivisible = true;
                foreach (var d in divisors)
                {
                    if (i % d != 0)
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    divisable.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",divisable));
        }
    }
}
