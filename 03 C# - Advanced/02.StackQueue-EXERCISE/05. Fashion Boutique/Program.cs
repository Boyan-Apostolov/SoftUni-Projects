using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersToAddToStack = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var clothes = new Stack<int>(numbersToAddToStack);

            int capacity = int.Parse(Console.ReadLine());

            int sum = 0;
            int rackCount = 1;

            while (clothes.Any())
            {
                sum += clothes.Peek();
                if (sum <= capacity)
                {
                    clothes.Pop();
                }
                else
                {
                    rackCount++;
                    sum = 0;
                }

            }
            Console.WriteLine(rackCount);
        }
    }
}
