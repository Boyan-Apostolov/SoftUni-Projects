using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchToCantimetre
{
    class Program
    {
        static void Main(string[] args)
        {
            double inch, cm;
            inch = double.Parse(Console.ReadLine());
            cm = inch * 2.54;
            Console.WriteLine("{0:F2}",cm);  //(cm)
        }
    }
}
