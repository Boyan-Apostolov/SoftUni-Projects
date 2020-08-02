using System;

namespace Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            double paperCount = int.Parse(Console.ReadLine());
            double paperCoverage = double.Parse(Console.ReadLine());

            double boxArea = sideSize * sideSize * 6;

            double coveredArea = 0.0;
            
            

            double thirdSheets = Math.Floor(paperCount/3);

            coveredArea = (paperCount - thirdSheets * 0.75) * paperCoverage;
            double percentage = (coveredArea / boxArea) * 100;
            Console.WriteLine($"You can cover {percentage:f2}% of the box.");
        }
    }
}
