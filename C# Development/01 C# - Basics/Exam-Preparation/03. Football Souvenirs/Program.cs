using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Football_Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string item = Console.ReadLine();
            int countItems = int.Parse(Console.ReadLine());
            double price = 0;
            bool isValidTeam = true;
            bool isValidItem = true;
            double totalPrice = 0;

            switch (team)
            {
                case "Argentina":
                    if (item == "flags")
                    {
                        price = 3.25;
                    }
                    else if (item == "caps")
                    {
                        price = 7.20;
                    }
                    else if (item == "posters")
                    {
                        price = 5.10;
                    }
                    else if (item == "stickers")
                    {
                        price = 1.25;
                    }
                    else
                    {
                        Console.WriteLine("Invalid stock!");
                        isValidItem = false;
                    }
                    break;

                case "Brazil":
                    if (item == "flags")
                    {
                        price = 4.20;
                    }
                    else if (item == "caps")
                    {
                        price = 8.50;
                    }
                    else if (item == "posters")
                    {
                        price = 5.35;
                    }
                    else if (item == "stickers")
                    {
                        price = 1.20;
                    }
                    else
                    {
                        Console.WriteLine("Invalid stock!");
                        isValidItem = false;
                    }
                    break;

                case "Croatia":
                    if (item == "flags")
                    {
                        price = 2.75;
                    }
                    else if (item == "caps")
                    {
                        price = 6.90;
                    }
                    else if (item == "posters")
                    {
                        price = 4.95;
                    }
                    else if (item == "stickers")
                    {
                        price = 1.10;
                    }
                    else
                    {
                        Console.WriteLine("Invalid stock!");
                        isValidItem = false;
                    }
                    break;

                case "Denmark":
                    if (item == "flags")
                    {
                        price = 3.10;
                    }
                    else if (item == "caps")
                    {
                        price = 6.50;
                    }
                    else if (item == "posters")
                    {
                        price = 4.80;
                    }
                    else if (item == "stickers")
                    {
                        price = 0.90;
                    }
                    else
                    {
                        Console.WriteLine("Invalid stock!");
                        isValidItem = false;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid country!");
                    isValidTeam = false;
                    break;
            }
            totalPrice = price * countItems;
            if (isValidTeam && isValidItem)
            {
                Console.WriteLine($"Pepi bought {countItems} {item} of {team} for {totalPrice:F2} lv.");
            }
        }
    }
}
