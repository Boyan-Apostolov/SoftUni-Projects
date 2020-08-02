using System;

namespace Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            var population = Console.ReadLine();
            int area = int.Parse(Console.ReadLine());


            Console.WriteLine($"Town {name} has population of {population} and area {area} square km");
        }
    }
}
