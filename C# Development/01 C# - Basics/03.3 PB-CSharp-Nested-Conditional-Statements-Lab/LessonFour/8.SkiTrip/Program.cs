using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {

            int days = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string feedback = Console.ReadLine();
            double price;
            double finalPrice;
            int nights = days - 1;

            if (typeRoom == "room for one person")
            {
                price = nights * 18.00;
                if (feedback == "positive")
                {
                    finalPrice = price + (price*0.25);
                    Console.WriteLine("{0:F2}", finalPrice);
                    
                }
                else if (feedback == "negative")
                {
                    finalPrice = price - (price * 0.10);
                    Console.WriteLine("{0:F2}",finalPrice);
                }
            }
            else if (typeRoom == "apartment")
            {
                if (days < 10)
                {
                    price = (nights * 25.00)- (nights * 25.00) * 0.30;
                    if (feedback == "positive")
                    {
                        price = price + (price * 0.25);
                    }
                    else if (feedback == "negative")
                    {
                        price = price - (price * 0.10);
                    }
                    Console.WriteLine("{0:F2}", price);
                }
                else if (days >= 10 && days <= 15)
                {
                    price = (nights * 25.00)- (nights * 25.00) * 0.35;
                    if (feedback == "positive")
                    {
                        price = price + (price * 0.25);
                    }
                    else if (feedback == "negative")
                    {
                        price = price - (price * 0.10);
                    }
                    Console.WriteLine("{0:F2}", price);
                }
                else if (days > 15)
                {
                    price = (nights * 25.00)- (nights * 25.00) * 0.50;
                    if (feedback == "positive")
                    {
                        price = price + (price * 0.25);
                    }
                    else if (feedback == "negative")
                    {
                        price = price - (price * 0.10);
                    }
                    Console.WriteLine("{0:F2}", price);
                }
            }
            else if (typeRoom == "president apartment")
            {
                if (days < 10)
                {
                    price = (nights * 35.00)- (nights * 35.00) * 0.10;
                    if (feedback == "positive")
                    {
                        price = price + (price * 0.25);
                    }
                    else if (feedback == "negative")
                    {
                        price = price - (price * 0.10);
                    }
                    Console.WriteLine("{0:F2}", price);
                }
                else if (days >= 10 && days <= 15)
                {
                    price = (nights * 35.00)- (nights * 35.00) * 0.35;
                    if (feedback == "positive")
                    {
                        price = price + (price * 0.25);
                    }
                    else if (feedback == "negative")
                    {
                        price = price - (price * 0.10);
                    }
                    Console.WriteLine("{0:F2}", price);
                }
                else if (days > 15)
                {
                    price = (nights * 35.00)- (nights * 35.00) * 0.20;
                    if (feedback == "positive")
                    {
                        price = price + (price * 0.25);
                    }
                    else if (feedback == "negative")
                    {
                        price = price - (price * 0.10);
                    }
                    Console.WriteLine("{0:F2}", price);
                }
            }

            
        }
    }
}
