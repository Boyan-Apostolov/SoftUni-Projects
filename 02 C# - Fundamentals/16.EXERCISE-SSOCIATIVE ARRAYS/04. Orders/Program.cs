using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, double> products = new Dictionary<string, double>();

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    if (input == "buy")
            //    {
            //        break;
            //    }

            //    string[] currentProduct = input.Split(" ");
            //    double pricePer = double.Parse(currentProduct[1]);
            //    double quantity = 0;
            //    double currentPrice = 0;
            //    string now = currentProduct[0];
            //    if (!products.ContainsKey(now))
            //    {
            //        quantity = double.Parse(currentProduct[2]);
            //        currentPrice = pricePer * quantity;
            //        products.Add(currentProduct[0], currentPrice);
            //    }
            //    else
            //    {
            //        double something = products[now];
            //        something /= currentPrice;
            //        something += double.Parse(currentProduct[2]);
            //        currentPrice = pricePer * something;
            //        products[now] = currentPrice;
            //    }
            //}

            //foreach (var product in products)
            //{
            //    Console.WriteLine($"{product.Key} -> {product.Value:f2}");
            //}


            var priceAndProduct = new Dictionary<string, double>();
            var countAndProduct = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(' ').ToArray();
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (product == "buy")
                {
                    break;
                }
                if (!countAndProduct.ContainsKey(product))
                {
                    countAndProduct[product] = 0;
                }
                countAndProduct[product] += quantity;
                if (!priceAndProduct.ContainsKey(product))
                {
                    priceAndProduct[product] = 0;
                }
                priceAndProduct[product] = price;
            }

            foreach (var kvp in countAndProduct)
            {
                string product = kvp.Key;
                int quantity = kvp.Value;
                double price = priceAndProduct[product];

                double result = quantity * price;
                Console.WriteLine($"{product} => {result}");
            }
        }
    }
}
