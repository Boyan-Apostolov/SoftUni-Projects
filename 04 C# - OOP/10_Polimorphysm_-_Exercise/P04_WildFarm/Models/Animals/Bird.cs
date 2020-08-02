using System;
using System.Collections.Generic;
using System.Text;

namespace P04_WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight,double wing) : base(name, weight)
        {
            this.WingSize = wing;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return  base.ToString() +$" { this.WingSize}, { this.Weight}, { this.FoodEaten}]";
        }
    }
}
