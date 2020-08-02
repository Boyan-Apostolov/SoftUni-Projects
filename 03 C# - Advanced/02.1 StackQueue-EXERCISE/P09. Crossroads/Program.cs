using System;
using System.Linq;
using System.Collections.Generic;
namespace P09._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightInterval = int.Parse(Console.ReadLine());
            int freeWindowINterval = int.Parse(Console.ReadLine());
            string command;
            Queue<string> cars = new Queue<string>();
            bool crash = false;
            string crashedCar = string.Empty;
            int hitIndex = -1;
            int passedCars = 0;
            while ((command = Console.ReadLine()) != "END")
            {
                int currentGreenLight = greenLightInterval;
                if (command == "green")
                {
                    while (cars.Any())

                    {
                        string car = cars.Peek();
                        int carLength = car.Length;
                        if (carLength <= currentGreenLight)
                        {
                            currentGreenLight -= carLength;
                            passedCars++;
                            cars.Dequeue();
                        }
                        else
                        {
                            carLength -= currentGreenLight;
                            if (carLength <= freeWindowINterval)
                            {
                                passedCars++;
                                cars.Dequeue();
                            }
                            else
                            {
                                crash = true;
                                crashedCar = car;
                                hitIndex = currentGreenLight + freeWindowINterval;

                            }
                            break;

                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                if (crash)
                {
                    break;
                }
            }
            if (crash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[hitIndex]}");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
