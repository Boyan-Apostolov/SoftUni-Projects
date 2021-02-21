using System;
using System.Collections.Generic;
using System.Text;
using P04_WildFarm.Models.Foods;

namespace P04_WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double weightMult = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return $"Woof!";
        }

        public override ICollection<Type> PrefferedFoods => new List<Type>() {typeof(Meat)};
        public override double WeightMultipier => weightMult;

        public override string ToString()
        {
            return base.ToString() + $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
