using System;
using System.Collections.Generic;
using System.Linq;
namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>(input);

            while (true)
            {
                string[] command = Console.ReadLine().ToLower().Split();

                if (command[0] == "and")
                {
                    stack.Push(int.Parse(command[1]));
                    stack.Push(int.Parse(command[2]));
                }
                else if (command[0] == "remove")
                {
                    int totalElementsToRemove = int.Parse(command[1]);

                    for (int i = 0; i < totalElementsToRemove; i++)
                    {
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
