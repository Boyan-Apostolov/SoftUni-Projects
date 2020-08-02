using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;

            for (int i = 0; i < numbers; i++)
            {
                int current = int.Parse(Console.ReadLine());

                if (minNumber > current)
                {
                    minNumber = current;
                }

                if (maxNumber < current)
                {
                    maxNumber = current;
                }
            }
            Console.WriteLine("Max number: {0}",maxNumber);
            Console.WriteLine("Min number: {0}",minNumber);
        }
    }
}
