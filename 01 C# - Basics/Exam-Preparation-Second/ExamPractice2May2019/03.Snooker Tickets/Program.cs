using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Snooker_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string typeTicket = Console.ReadLine();
            int ticketCount = int.Parse(Console.ReadLine());
            string confirm = Console.ReadLine();
            double price = 0;

            if (stage == "Quarter final")
            {
                if (typeTicket == "Standard")
                {
                    price = 55.50;
                }
                else if (typeTicket == "Premium")
                {
                    price = 105.20;
                }
                else if (typeTicket == "VIP")
                {
                    price = 118.90;
                }
            }
            else if (stage == "Semi final")
            {
                if (typeTicket == "Standard")
                {
                    price = 75.88;
                }
                else if (typeTicket == "Premium")
                {
                    price = 125.55;
                }
                else if (typeTicket == "VIP")
                {
                    price = 300.40
;
                }
            }
            else if (stage == "Final")
            {
                if (typeTicket == "Standard")
                {
                    price = 110.10;
                }
                else if (typeTicket == "Premium")
                {
                    price = 160.66;
                }
                else if (typeTicket == "VIP")
                {
                    price = 400;
                }
            }

            double totalTicketPrice = price * ticketCount;

            if (totalTicketPrice >= 4000)
            {
                totalTicketPrice -= 0.25 * totalTicketPrice;
            }
            else if (totalTicketPrice >=2500)
            {
                totalTicketPrice -= 0.10 * totalTicketPrice;
                if (confirm == "Y")
                {
                    totalTicketPrice += 40*ticketCount;
                }
            }
            Console.WriteLine($"{totalTicketPrice:f2}");

        }
    }
}
