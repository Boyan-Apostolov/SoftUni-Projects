using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> comparator = new Func<int, int, int>((a, b) =>
                  {
                      if (a % 2 == 0 && b % 2 != 0)
                      {
                          return -1;
                      }
                      else if (a % 2 != 0 && b % 2 == 0)
                      {
                          return 1;
                      }
                      else
                      {
                          return a.CompareTo(b);
                      }
                  });

            Comparison<int> comparizon = new Comparison<int>(comparator);

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(nums, comparizon);

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
