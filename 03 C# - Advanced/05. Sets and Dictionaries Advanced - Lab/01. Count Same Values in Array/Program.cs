using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> dictionary = new Dictionary<double, int>();

            foreach (var currentNumber in input)
            {
                if (dictionary.ContainsKey(currentNumber))
                {
                    dictionary[currentNumber]++;
                }
                else
                {
                    dictionary[currentNumber] = 1;
                }
            }

            foreach (var num in dictionary)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
