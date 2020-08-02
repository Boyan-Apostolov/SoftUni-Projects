using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(", ").Select(double.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] += numbers[i] * 0.2;
                Console.WriteLine($"{numbers[i]:f2}");
            }
        }
    }
}
