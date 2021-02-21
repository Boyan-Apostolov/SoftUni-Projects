using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] previousOrders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var orders = new Queue<int>(previousOrders);
            var orderCount = orders.Count;
            var counter = 0;
            List<int> UNcompletedOrders = new List<int>();
            Console.WriteLine(orders.Max());

            foreach (var order in orders)
            {
                if (order <= quantityOfFood)
                {
                    quantityOfFood -= order;
                    
                    counter++;
                }
                else
                {
                    UNcompletedOrders.Add(order);
                }
            }

            if (counter==orderCount)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write("Orders left: ");
                Console.Write(string.Join(" ",UNcompletedOrders));
            }

        }
    }
}
