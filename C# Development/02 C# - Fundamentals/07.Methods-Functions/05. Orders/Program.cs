using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {

            //•	coffee – 1.50 water – 1.00 coke – 1.40 snacks – 2.00
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double a = 0;
            if (product == "coffee")
            {
                a = 1.5*quantity;
                Console.WriteLine($"{a:f2}");
            }
            else if (product == "water")
            {
                a = 1*quantity;
                Console.WriteLine($"{a:f2}");
            }
            else if (product == "coke")
            {
                a = 1.4*quantity;
                Console.WriteLine($"{a:f2}");
            }
            else if (product == "snacks")
            {
                a = 2.0*quantity;
                Console.WriteLine($"{a:f2}");
            }

        }
    }
}
