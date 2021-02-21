using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Batchelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double forSpecialQuest = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double price = 0;
            int guests = 0;
            int people = 0;

            while (command != "The restaurant is full")
            {
                people = int.Parse(command);

                if (people < 5)
                {
                    price += people * 100;
                }
                else if (people >= 5)
                {
                    price += people * 70;
                }
                guests += people;
                people = 0;
                command = Console.ReadLine();
            }

            if (price >= forSpecialQuest)
            {
                Console.WriteLine($"You have {guests} guests and {price-forSpecialQuest} leva left.");
            }
            else if (forSpecialQuest > price)
            {
                Console.WriteLine($"You have {guests} guests and {price} leva income, but no singer.");
            }
        }
    }
}
