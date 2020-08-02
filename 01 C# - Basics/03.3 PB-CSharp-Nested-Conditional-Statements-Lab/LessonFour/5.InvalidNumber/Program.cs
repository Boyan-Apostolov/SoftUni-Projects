using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            if (  (number == 0) || (number >= 100 && number <= 200) )
            {
                int lol = 0;
            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
