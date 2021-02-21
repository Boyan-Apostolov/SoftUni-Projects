using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fan_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int numberItems = int.Parse(Console.ReadLine());
            string item = "";
            int totalPrice = 0;
            for (int i = 1; i <= numberItems; i++)
            {
                item = Console.ReadLine();

                if (item == "hoodie")
                {
                    totalPrice += 30;
                }
                else if (item == "keychain")
                {
                    totalPrice += 4;
                }
                else if (item == "T-shirt")
                {
                    totalPrice += 20;
                }
                else if (item == "flag")
                {
                    totalPrice += 15;
                }
                else if (item == "sticker")
                {
                    totalPrice += 1;
                }
            }
            if (budget >= totalPrice)
            {
                int moneyLeft = budget - totalPrice;
                Console.WriteLine($"You bought {numberItems} items and left with {moneyLeft} lv.");
            }
            else
            {
                int moneyNeeded = totalPrice - budget;
                Console.WriteLine($"Not enough money, you need {moneyNeeded} more lv.");
            }
        }
    }
}
