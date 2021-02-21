using System;
using System.Collections.Generic;
using System.Linq;
namespace _1._Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list.Count <= i+1)
                {
                    break;
                }
                var valueAtIndex = list[i];
                var valueAfterIndex = list[i + 1];

                if (valueAtIndex == valueAfterIndex)
                {
                    list[i] = valueAfterIndex + valueAfterIndex;
                    list.RemoveAt(i + 1);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ",list));
        }
    }
}
