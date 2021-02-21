using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int pile, riba, veg;
            double cenaPile, cenaRiba, cenaVeg, Total, desert, obshtoMenu, dostavka;
            pile = int.Parse(Console.ReadLine());
            riba = int.Parse(Console.ReadLine());
            veg = int.Parse(Console.ReadLine());
            cenaPile = pile * 10.35;
            cenaRiba = riba * 12.40;
            cenaVeg = veg * 8.15;
            obshtoMenu = cenaVeg + cenaRiba + cenaPile;
            desert = obshtoMenu * 0.20;                                                             
            dostavka = 2.5;
            Total = obshtoMenu + desert + dostavka;
            Console.WriteLine("Total: {0}",Total);



        }
    }
}
//https://softuni.bg/downloads/svn/programming-basics-v4/course-directories/may-2019/2019-03/Retake-Exam/01.%20Food%20Delivery.pdf
