using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using _03_ShoppingSpree.Models;

namespace _03_ShoppingSpree.Core
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> people;

        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }

        public void Run()
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                persons = Console.ReadLine().Split(';').ToList()
                    .Select(t => t.Split('='))
                    .Select(p => new Person(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                products = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                    .Select(t => t.Split('='))
                    .Select(p => new Product(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();
                var person = persons.First(p => p.Name == tokens[0]);
                var product = products.First(p => p.Name == tokens[1]);

                Console.WriteLine(person.AddProductToBag(product));
            }

            persons.ForEach(p => Console.WriteLine(p));
        }

    }
}
