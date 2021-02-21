using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            string longNum = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            int temp = 0;
            foreach (char ch in longNum.Reverse())
            {
                int digit = int.Parse(ch.ToString());
                int result = digit * num + temp;

                int resDigit = result % 10;
                sb.Insert(0, resDigit);
                temp = result / 10;

            }

                if (temp > 0)
                {
                    sb.Insert(0, temp);
                }

            string finalNumber = sb.ToString().TrimStart('0');

            if (finalNumber.Length == 0)
            {
                finalNumber = "0";
            }



            Console.WriteLine(finalNumber);
        }
    }
}
