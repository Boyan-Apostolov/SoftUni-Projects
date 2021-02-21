using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Christmas_Sweets
{
    class Program
    {
        static void Main(string[] args)
        {
            double baklavaPrice = double.Parse(Console.ReadLine());
            double muffinPrice = double.Parse(Console.ReadLine());
            double cakeQuantity = double.Parse(Console.ReadLine());
            double candyQuantity = double.Parse(Console.ReadLine());
            int bisquitQuantity = int.Parse(Console.ReadLine());

            double cakePrice =  baklavaPrice+(0.6 * baklavaPrice);
            double candyPrice = muffinPrice + (0.8*muffinPrice);
            double bisquitPrice = 7.50;

            double totalPrice = (cakePrice * cakeQuantity) + (candyPrice * candyQuantity) + (bisquitPrice * bisquitQuantity);
            Console.WriteLine($"{totalPrice:F2}");

        }
    }
}
