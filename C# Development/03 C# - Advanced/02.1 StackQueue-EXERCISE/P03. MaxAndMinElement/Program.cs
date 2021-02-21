using System;
using System.Linq;
using System.Collections.Generic;

namespace P03._MaxAndMinElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "1")
                {
                    int elToPush = int.Parse(cmdArgs[1]);
                    numbers.Push(elToPush);
                }
                else if (cmdType == "2")
                {
                    if (numbers.Any())
                    {
                        numbers.Pop();
                    }
                }

                else if (cmdType == "3")
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }
                else if (cmdType == "3")
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
