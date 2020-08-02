using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePandS
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double P = 2 * r * Math.PI;
            double S = Math.PI * (r * r);
            Console.WriteLine("{0:F2}",S);
            Console.WriteLine("{0:F2}",P);
        }
    }
}
