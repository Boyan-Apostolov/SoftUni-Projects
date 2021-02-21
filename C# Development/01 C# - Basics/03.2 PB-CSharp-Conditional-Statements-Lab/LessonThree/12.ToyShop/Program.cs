using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            double numberPuzzels = double.Parse(Console.ReadLine());
            double numberDolls = double.Parse(Console.ReadLine());
            double numberBears = double.Parse(Console.ReadLine());
            double numberMinions = double.Parse(Console.ReadLine());
            double numberTrucks = double.Parse(Console.ReadLine());

            double pricePuzzles = numberPuzzels * 2.60;
            double priceDolls = numberDolls * 3;
            double priceBears = numberBears * 4.10;
            double priceMinions = numberMinions * 8.20;
            double priceTrucks = numberTrucks * 2;

            double totalToys = numberPuzzels + numberDolls + numberBears + numberMinions + numberTrucks;
            double totalPrice = pricePuzzles + priceDolls + priceBears + priceMinions + priceTrucks;

            double discount = 0;
            double rent = 0;
            double moneyLeft = 0;
            double moneyNeeded = 0;

            if (totalToys>=50)
            {
                discount = totalPrice * 0.25;
                totalPrice = totalPrice - discount;
            }
            rent = totalPrice * 0.10;
            totalPrice = totalPrice - rent;
            if (totalPrice>=tripPrice)
            {
                moneyLeft = totalPrice - tripPrice;
                Console.WriteLine("Yes! {0:F2} lv left.",moneyLeft);
            }
            else if (totalPrice<tripPrice)
            {
                moneyNeeded = tripPrice - totalPrice;
                Console.WriteLine("Not enough money! {0:F2} lv needed.", moneyNeeded);
            }


        }
    }
}
