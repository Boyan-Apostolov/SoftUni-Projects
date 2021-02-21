using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            double currentMoney = 0;
            double moneyPouch = 0;
            input = Console.ReadLine();
            double moneyForItem = 0;
            string item = null;
            while (true)
            {
                
                if (input == "Start")
                {
                    break;
                }

                currentMoney = double.Parse(input);
                if (currentMoney == 0.1 || currentMoney == 0.2 || currentMoney == 0.5 || currentMoney == 1 || currentMoney == 2)
                {
                    moneyPouch += currentMoney;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentMoney}");
                }
                input = Console.ReadLine();
            }

            while (true)
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                item = input;

                if (item == "Nuts")
                {
                    moneyForItem = 2.0;
                }
                else if (item == "Water")
                {
                    moneyForItem = 0.7;
                }
                else if (item == "Crisps")
                {
                    moneyForItem = 0.5;
                }
                else if (item == "Soda")
                {
                    moneyForItem = 1.0;
                }
                else if (item == "Coke")
                {
                    moneyForItem = 2.0;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                if (moneyPouch < moneyForItem)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else
                {
                    item.ToLower();
                    Console.WriteLine($"Purchased {item}");
                    moneyPouch -= moneyForItem;
                }

                

            }
            Console.WriteLine($"Change: {moneyPouch}");
        }
    }
}
