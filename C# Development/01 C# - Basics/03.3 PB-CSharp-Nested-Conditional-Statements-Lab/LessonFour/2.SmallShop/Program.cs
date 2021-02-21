using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double allPrice = 0;

            if (town == "Sofia")
            {
                if (product == "coffee")
                {
                    allPrice = quantity * 0.50;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "water")
                {
                    allPrice = quantity * 0.80;                    
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "beer")
                {
                    allPrice = quantity * 1.20;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "sweets")
                {
                    allPrice = quantity * 1.45;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "peanuts")
                {
                    allPrice = quantity * 1.60;
                    Console.WriteLine(allPrice.ToString());
                }
            }
            else if (town == "Plovdiv")
            {
                if (product == "coffee")
                {
                    allPrice = quantity * 0.40;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "water")
                {
                    allPrice = quantity * 0.70;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "beer")
                {
                    allPrice = quantity * 1.15;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "sweets")
                {
                    allPrice = quantity * 1.30;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "peanuts")
                {
                    allPrice = quantity * 1.50;
                    Console.WriteLine(allPrice.ToString());
                }
            }
            else if (town == "Varna")
            {
                if (product == "coffee")
                {
                    allPrice = quantity * 0.45;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "water")
                {
                    allPrice = quantity * 0.70;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "beer")
                {
                    allPrice = quantity * 1.10;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "sweets")
                {
                    allPrice = quantity * 1.35;
                    Console.WriteLine(allPrice.ToString());
                }
                else if (product == "peanuts")
                {
                    allPrice = quantity * 1.55;
                    Console.WriteLine(allPrice.ToString());
                }
            }
        }
    }
}
