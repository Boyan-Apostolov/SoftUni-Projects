using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            long factorial = 1;
            for (int i = 1; i <= firstNum; i++)
            {
                factorial *= i;
            }
            long factorialTwo = 1;
            for (int i = 1; i <= secondNum; i++)
            {
                factorialTwo *= i;
            }
            double result = factorial *1.0/ factorialTwo;
            Console.WriteLine($"{result:f2}");
        }
    }
}
