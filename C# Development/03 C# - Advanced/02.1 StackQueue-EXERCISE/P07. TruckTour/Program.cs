using System;
using System.Linq;
using System.Collections.Generic;
namespace P07._TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                int[] currPump = Console.ReadLine().Split().Select(int.Parse).ToArray();

                pumps.Enqueue(currPump);
            }

            while (true)
            {
                int fuelAmount = 0;
                bool foundPoint = true;
                for (int i = 0; i < n; i++)
                {
                    int[] currPump = pumps.Dequeue();

                    fuelAmount += currPump[0];

                    if (fuelAmount < currPump[1])
                    {
                        foundPoint = false;
                    }

                    fuelAmount -= currPump[1];

                    pumps.Enqueue(currPump);
                }

                if (foundPoint)
                {
                    break;
                }
                counter++;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(counter);
        }
    }
}
