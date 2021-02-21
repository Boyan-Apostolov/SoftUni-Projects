using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string query = Console.ReadLine();

            Predicate<int> predicate = query == "odd" ? new Predicate<int>((n) => n % 2 != 0) : new Predicate<int>((n) => n % 2 == 0);

            List<int> result = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }
            
            Console.WriteLine(string.Join(" ", result));
        }
    }

}
