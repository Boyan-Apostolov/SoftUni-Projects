using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string day = Console.ReadLine();
            double currentPrice = 0;
            double totalPrice = 0;

            if (day == "Friday")
            {
                if (typeOfPeople == "Students")
                {
                    currentPrice = 8.45;
                }
                else if (typeOfPeople =="Business")
                {
                    currentPrice = 10.90;
                }
                else if (typeOfPeople == "Regular")
                {
                    currentPrice = 15;
                }
            }
            else if (day == "Saturday")
            {
                if (typeOfPeople == "Students")
                {
                    currentPrice = 9.50;
                }
                else if (typeOfPeople == "Business")
                {
                    currentPrice = 15.60;
                }
                else if (typeOfPeople == "Regular")
                {
                    currentPrice = 20;
                }
            }
            else if (day == "Sunday")
            {
                if (typeOfPeople == "Students")
                {
                    currentPrice = 10.46;
                }
                else if (typeOfPeople == "Business")
                {
                    currentPrice = 16;
                }
                else if (typeOfPeople == "Regular")
                {
                    currentPrice = 22.50;
                }
            }

            totalPrice = currentPrice * numberOfPeople;

            if (typeOfPeople == "Students" && numberOfPeople >= 30)
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }
            else if (typeOfPeople == "Business" && numberOfPeople >= 100)
            {
                totalPrice = totalPrice - ( 10 * currentPrice);
            }
            else if (typeOfPeople == "Regular" && (numberOfPeople >=10 && numberOfPeople<=20 ))
            {
                totalPrice = totalPrice - (totalPrice * 0.05);
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
