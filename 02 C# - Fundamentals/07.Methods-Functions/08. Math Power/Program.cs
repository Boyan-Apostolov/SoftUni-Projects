using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = int.Parse(Console.ReadLine());
            double power = int.Parse(Console.ReadLine());
            double result = Math.Pow(number, power);
            Console.WriteLine(result);
        }
    }
}
