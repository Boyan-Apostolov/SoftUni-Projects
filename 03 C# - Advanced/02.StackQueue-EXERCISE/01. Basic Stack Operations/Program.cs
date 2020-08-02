using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numbersToAddToStack = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbers = new Stack<int>(numbersToAddToStack);

            int itemsToPush = n[0];
            int itemsToPop = n[1];
            int itemsHere = n[2];

           

            for (int i = 0; i < itemsToPop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(itemsHere))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Count > 0 ? numbers.Min() : 0);
            }
        }
    }
}
