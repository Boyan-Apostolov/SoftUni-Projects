using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine().Split(" ").ToArray();

            string result = null;

            foreach (var currentWord in inputArray)
            {
                for (int i = 0; i < currentWord.Length; i++)
                {
                    result += currentWord;
                }
            }

            Console.WriteLine(result);
        }
    }
}
