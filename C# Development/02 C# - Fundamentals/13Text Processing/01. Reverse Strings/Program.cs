using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            while (true)
            {
                if (input == "end")
                {
                    break;
                }
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    sb.Append(input[i]);
                }
                Console.WriteLine($"{input} = {sb}");
                sb = new StringBuilder();
                input = Console.ReadLine();
            }



        }
    }
}
