using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Beer_And_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beers = int.Parse(Console.ReadLine());
            int snacks = int.Parse(Console.ReadLine());
            double beerPrice = 0;
            double snacksPrice = 0;
            double totalMoney = 0;
            double moneyNeeded = 0;
            double moneyLeft = 0;


            beerPrice = beers * 1.2;
            snacksPrice = 0.45 * beerPrice;
            snacksPrice *= snacks;
            snacksPrice = Math.Ceiling(snacksPrice);
            totalMoney = snacksPrice + beerPrice;

            if (totalMoney <= budget)
            {
                moneyLeft = budget-totalMoney;
                Console.WriteLine($"{name} bought a snack and has {moneyLeft:f2} leva left.");
            }
            else
            {
                moneyNeeded = totalMoney - budget;
                Console.WriteLine($"{name} needs {moneyNeeded:f2} more leva!");
            }

        }
    }
}
