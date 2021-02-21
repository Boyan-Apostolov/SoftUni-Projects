using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.CleverLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingmachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int totalToyPrice = 0;
            int totalMoneyGift = 0;
            double totalMoney = 0;
            int previousBdayMoneyGift = 0;
            double moneyDiff = 0;

            for (int i = 0; i < age; i++)
            {
              int bday = i + 1;

                
                if (bday % 2 == 0)
                {

                    totalMoneyGift += 10 + previousBdayMoneyGift - 1;
                    previousBdayMoneyGift += 10;
                }
                else
                {
                    totalToyPrice += toyPrice;
                }
            }

            totalMoney = totalMoneyGift + totalToyPrice;


            if (totalMoney >= washingmachinePrice)
            {
                moneyDiff = totalMoney - washingmachinePrice;
                Console.WriteLine("Yes! {0:F2}", moneyDiff);
            }
            else
            {
                moneyDiff = washingmachinePrice - totalMoney;
                Console.WriteLine("No! {0:F2}", moneyDiff);
            }
            
        }
    }
}
