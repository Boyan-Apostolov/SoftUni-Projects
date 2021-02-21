using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var productShop = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] inputInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = inputInfo[0];
                string productName = inputInfo[1];
                double productPrice = double.Parse(inputInfo[2]);

                if (!productShop.ContainsKey(shopName))
                {
                    productShop.Add(shopName, new Dictionary<string, double>());
                }

                if (!productShop[shopName].ContainsKey(productName))
                {
                    productShop[shopName].Add(productName, productPrice);
                }



                input = Console.ReadLine();
            }

            foreach (var (shopName,products) in productShop.OrderBy(x=> x.Key))
            {
                Console.WriteLine($"{shopName}->");
                foreach (var currentProduct in products)
                {
                    Console.WriteLine($"Product: {currentProduct.Key}, Price: {currentProduct.Value}");
                }
            }
        }
    }
}
