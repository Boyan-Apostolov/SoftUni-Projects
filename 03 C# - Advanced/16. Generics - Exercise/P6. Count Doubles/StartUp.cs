using System;
using System.Collections.Generic;

namespace please
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> elements = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double value = double.Parse(Console.ReadLine());
                elements.Add(value);
            }

            Box<double> box = new Box<double>(elements);
            double elToCompare = double.Parse(Console.ReadLine());
            int count = box.CountGreaterElements(elements, elToCompare);
            Console.WriteLine(count);
        }
    }
}
