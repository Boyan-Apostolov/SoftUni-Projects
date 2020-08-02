using System;
using System.Collections.Generic;
using System.Text;
using P04_WildFarm.Models.Animals.Contracts;
using P04_WildFarm.Models.Foods.Contracts;

namespace P04_WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string UneatableMessage = "{0} does not eat {1}!";
        public Animal(string name,double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public abstract ICollection<Type> PrefferedFoods { get; }
        public abstract double WeightMultipier { get; }

        public void Feed(IFood food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!"); //May Error
            }

            this.Weight += this.WeightMultipier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
