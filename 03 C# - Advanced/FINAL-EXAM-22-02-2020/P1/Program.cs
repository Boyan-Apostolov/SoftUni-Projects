using System;
using System.Collections.Generic;
using System.Linq;
namespace P1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputFirstBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputSecondBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(inputFirstBox);
            Stack<int> secondBox = new Stack<int>(inputSecondBox);

            List<int> claimedItems = new List<int>();

            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                int firstBoxItem = firstBox.Peek();
                int secondBoxItem = secondBox.Peek();

                int sum = firstBoxItem + secondBoxItem;

                if (sum % 2 == 0)
                {
                    claimedItems.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!secondBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
