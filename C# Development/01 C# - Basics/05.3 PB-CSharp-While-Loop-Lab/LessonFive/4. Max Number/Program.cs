using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Max_Number
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
                int inputNumbers = int.Parse(Console.ReadLine());
                if (inputNumbers>minNumber)
                {
                    minNumber = inputNumbers;
                }
                k++;
            }
            Console.WriteLine(minNumber);
        }
    }
}
