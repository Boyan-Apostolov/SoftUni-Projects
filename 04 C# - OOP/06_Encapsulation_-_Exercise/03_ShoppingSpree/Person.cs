using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using _03_ShoppingSpree.Common;
using _03_ShoppingSpree.Models;

namespace _03_ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }


        public decimal Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string AddProductToBag(Product product)
        {
            if (this.Money < product.Price)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.Money -= product.Price;
            this.bag.Add(product);
            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {String.Join(", ", this.bag.Select(p => p.Name))}";
        }
    }
}
