using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
namespace _03._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger largeInteger = 1;

            for (int i = 2; i <= n; i++)
            {
                largeInteger *= i;
            }
            Console.WriteLine(largeInteger);
        }
    }
}
