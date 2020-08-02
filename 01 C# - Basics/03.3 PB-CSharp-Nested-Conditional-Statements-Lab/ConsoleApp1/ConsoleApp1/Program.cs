using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (day == "Sunday" || day == "Saturday")
            {
                switch (fruit)
                {
                    case "banana":
                        double price = quantity * 2.70;
                        Console.WriteLine(price);
                        break;
                    case "apple":
                        price = quantity * 1.25;
                        Console.WriteLine("{0:F2}",price);
                        break;
                    case "orange":
                        price = quantity * 0.90;
                        Console.WriteLine("{0:F2}", price);
                        break;
                    case "grapefruit":
                        price = quantity * 1.60;
                        Console.WriteLine("{0:F2}", price);
                        break;
                    case "kiwi":
                        price = quantity * 3.00;
                        Console.WriteLine("{0:F2}", price);
                        break;
                    case "pineapple":
                        price = quantity * 5.60;
                        Console.WriteLine("{0:F2}", price);
                        break;
                    case "grapes":
                        price = quantity * 4.20;
                        Console.WriteLine("{0:F2}", price);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                
            }
            else if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {

            }
                                                                    
        }
    }
}
