using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _04_PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var tokens = Console.ReadLine().Split();
                Pizza pizza = new Pizza(tokens[1]);
                tokens = Console.ReadLine().Split();
                pizza.Dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    tokens = command.Split();
                    pizza.AddTopping(new Topping(tokens[1], int.Parse(tokens[2])));
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
