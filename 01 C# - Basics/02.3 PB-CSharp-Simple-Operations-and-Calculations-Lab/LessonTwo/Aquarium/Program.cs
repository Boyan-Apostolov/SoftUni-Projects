using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            double wight, height, depth, percent,total,finalPercent,area,realArea;
            depth = double.Parse(Console.ReadLine());
            wight = double.Parse(Console.ReadLine());
            height = double.Parse(Console.ReadLine());
            percent = double.Parse(Console.ReadLine());
            finalPercent = percent * 0.01;
            area = depth * wight * height;
            realArea = area * 0.001;
            total = realArea * (1 - finalPercent);
            Console.WriteLine("{0:F3}",total);
        }
    }
}
