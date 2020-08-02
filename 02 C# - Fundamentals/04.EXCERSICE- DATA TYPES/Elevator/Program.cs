using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = int.Parse(Console.ReadLine());
            int capacity= int.Parse(Console.ReadLine());
            double result = Math.Ceiling( total *1.0 /capacity);
            Console.WriteLine(result);

        }
    }
}
