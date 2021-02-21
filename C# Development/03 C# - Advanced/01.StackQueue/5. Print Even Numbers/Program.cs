using System;
using System.Collections.Generic;
using System.Linq;
namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbers = new Queue<int>(arrayOfNumbers);
            var finalList = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    finalList.Add(number);
                }
            }
            Console.WriteLine(string.Join(", ", finalList));
        }
    }
}
