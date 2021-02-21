using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs, others;
            double forDogs, forOthers, Total;
            dogs = int.Parse(Console.ReadLine());
            others = int.Parse(Console.ReadLine());
            forDogs = dogs * 2.5;
            forOthers = others * 4;
            Total = forDogs + forOthers;
            Console.WriteLine("{0:F2} lv.", Total);
        }
    }
}
