using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari
{
    class Program
    {
        static void Main(string[] args)
        {
           
            double cenaGorivo, obshtosEx, budget, litraGorivo, all, needed,aftertax;
            string den;
            budget = double.Parse(Console.ReadLine());
            litraGorivo = double.Parse(Console.ReadLine());
            den = Console.ReadLine();
            cenaGorivo = litraGorivo * 2.10;
            obshtosEx = (cenaGorivo + 100);
            all = obshtosEx - (20% obshtosEx);                                                       // % Miscalculate
            needed = all - budget;
            aftertax = budget - all;
            while (den == "Sunday")
            {
                
                if (budget > all)
                {
                    Console.WriteLine("Safaty time! Money left: {0} lv.", aftertax); break;
                }
                else
                {
                    Console.WriteLine("Not enough money! Money needed: {0} lv.", needed); break;
                }
            }
            while (den == "Saturday")
            {
                if (budget < all)
                {
                    Console.WriteLine("Not enough money! Money needed: {0} lv.", needed); break;
                }
                else
                {
                    Console.WriteLine("Safaty time! Money left: {0} lv.", aftertax); break;
                }
            }
           
        }
    }
}
//https://softuni.bg/downloads/svn/programming-basics-v4/course-directories/may-2019/2019-03/Retake-Exam/02.%20Safari.pdf
