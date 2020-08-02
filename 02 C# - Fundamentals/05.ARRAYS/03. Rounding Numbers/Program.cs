using System;
using System.Linq;


namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string[] items = numbers.Split();
            double[] doubleArray = new double[items.Length];
            double current = 0;
            double something = 0;
            for (int i = 0; i < items.Length; i++)
            {
                doubleArray[i] = double.Parse(items[i]);
                something = doubleArray[i];
                current = Math.Round(doubleArray[i], MidpointRounding.AwayFromZero);
                Console.WriteLine(items[i]+" "+"=>"+" "+current);
            }
        }
    }
}
