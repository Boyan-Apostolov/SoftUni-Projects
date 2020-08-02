using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.NumberInRange1_100
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            while (input <1 || (input >100))
            {
                Console.WriteLine("Invalid number!");
                input = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The number is: {0}",input);
        }
    }
}
