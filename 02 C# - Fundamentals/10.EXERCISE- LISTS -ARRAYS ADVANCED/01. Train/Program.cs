using System;
using System.Linq;
using System.Collections.Generic;
namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] tokens = line.Split(' ');

                //Add wagon
                if (tokens.Length == 2)
                {
                    int waggon = int.Parse(tokens[1]);
                    train.Add(waggon);
                }
                else
                {
                    int currentCapacity = int.Parse(tokens[0]);
                    FindWagon(train, maxCapacity, currentCapacity); // Goto FindWagon function
                    
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ',train)); 
        }

        //FindWagon function
        static void FindWagon(List<int> train, int maxCapacity, int currentCapacity)
        {
            for (int i = 0; i < train.Count; i++)
            {
                int currentWagon = train[i];
                if ((currentWagon + currentCapacity) <= maxCapacity)
                {
                    train[i] += currentCapacity;
                    break;
                }
            }
        }
    }
}
