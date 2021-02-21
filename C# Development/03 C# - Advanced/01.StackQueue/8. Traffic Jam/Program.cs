using System;
using System.Collections.Generic;
using System.Linq;
namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var passingCars = int.Parse(Console.ReadLine());
            int totalCarsPassed = 0;
            Queue<string> cars = new Queue<string>();
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "green")
                {
                    for (int i = 0; i < passingCars; i++)
                    {
                        if (cars.Any())
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            totalCarsPassed++;
                        }
                    }
                }
                else if (command == "end")
                {
                    break;
                }
                else
                {
                    cars.Enqueue(command);
                }


            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}
