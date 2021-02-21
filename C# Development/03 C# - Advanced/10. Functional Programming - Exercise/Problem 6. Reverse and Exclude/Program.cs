using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());
            List<int> ok = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % n != 0)
                {
                    ok.Add(numbers[i]);
                }
            }
            ok.Reverse();
            Console.WriteLine(string.Join(" ", ok));
        }
    }
}
