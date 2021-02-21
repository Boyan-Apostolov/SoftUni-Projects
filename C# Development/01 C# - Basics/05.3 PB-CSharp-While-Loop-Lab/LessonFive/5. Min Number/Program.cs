using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int k = 0;
            int minNumber = int.MaxValue;
            while (numbers>k)
            {
                int input = int.Parse(Console.ReadLine());
                if (input < minNumber)
                {
                    minNumber = input;
                }
                k++;
            }
            Console.WriteLine(minNumber);
        }
    }
}
