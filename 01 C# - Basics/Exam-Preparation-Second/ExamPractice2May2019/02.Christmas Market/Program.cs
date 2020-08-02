using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Christmas_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double goal = double.Parse(Console.ReadLine());
            int fantasyCount = int.Parse(Console.ReadLine());
            int horrorCount = int.Parse(Console.ReadLine());
            int romanticCount = int.Parse(Console.ReadLine());
            double forSellers = 0;

            double priceWithoutTax = (fantasyCount * 14.9) + (horrorCount * 9.8) + (romanticCount * 4.3);
            double priceWithTax = priceWithoutTax - (0.2 * priceWithoutTax);

            if (priceWithTax >= goal)
            {
                double overGoal = priceWithTax - goal ;
                double forOperators = goal - overGoal ;
                Console.WriteLine($" {priceWithTax} leva donated.");
            }
            else
            {
                double moneyNeeded = goal - priceWithTax;
                Console.WriteLine($"{moneyNeeded} money needed.");
            }
        }
    }
}
