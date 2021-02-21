using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = numbers[0];
            int m = numbers[1];

            HashSet<int> nSET = new HashSet<int>();
            HashSet<int> mSET = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                nSET.Add(number);
            }

            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                mSET.Add(number);
            }
            Console.WriteLine(string.Join(" ", nSET.Intersect(mSET)));

        }
    }
}
