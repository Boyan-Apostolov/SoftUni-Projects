using System;
using System.Collections.Generic;
using System.Linq;
namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new Queue<string>();
            string currentName = Console.ReadLine();

            while (currentName != "End")
            {
                if (currentName== "Paid")
                {
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer);
                    }
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(currentName);
                }


                currentName = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");

        }
    }
}
