using System;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 0;
            int numberOfLines = int.Parse(Console.ReadLine());
            int counter = 0;
            int water = 0;
            while (counter < numberOfLines)
            {
                water = int.Parse(Console.ReadLine());
                capacity += water;
                if (capacity > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    capacity -= water;
                }
                counter++;
            }
            Console.WriteLine(capacity);
        }
    }
}
