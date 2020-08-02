using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowMuchGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            double discount, price, Total;
            double meters = double.Parse(Console.ReadLine());
            price = meters * 7.61;
            discount = 0.18 * price;
            Total = price - discount;
            Console.WriteLine("The final price is: {0:F2} lv.", Total);
            Console.WriteLine("The discount is: {0:F2} lv.",discount);
                                 
        }
    }
}
