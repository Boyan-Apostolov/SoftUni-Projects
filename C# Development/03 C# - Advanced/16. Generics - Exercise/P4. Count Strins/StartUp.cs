using System;
using System.Collections.Generic;

namespace please
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> elements = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();
                elements.Add(value);
            }

            Box<string> box = new Box<string>(elements);
            string elToCompare = Console.ReadLine();
            int count = box.CountGreaterElements(elements, elToCompare);
            Console.WriteLine(count);
        }
    }
}
