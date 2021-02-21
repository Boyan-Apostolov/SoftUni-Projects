using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._ExerciseOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] malesINput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[] femalesINput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Stack<int> males = new Stack<int>(malesINput);
            Queue<int> females = new Queue<int>(femalesINput);
            int matches = 0;
            while (males.Count > 0 && females.Count > 0)
            {
                int currentMale = males.Peek();
                int currentFemale = females.Peek();
                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }

                if (currentFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    if (males.Count > 0)
                    {
                        males.Pop();
                    }
                    continue;
                }

                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Count > 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }

                if (currentFemale==currentMale)
                {
                    matches++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop()-2);
                }
            }

            Console.WriteLine($"Matches: {matches}");

            string malesstr = males.Count > 0 ? string.Join(", ", males) : "none";
            Console.WriteLine($"Males left: {malesstr}");

            string femalesstr = females.Count > 0 ? string.Join(", ", females) : "none";
            Console.WriteLine($"Males left: {femalesstr}");
            
        }
    }
}
