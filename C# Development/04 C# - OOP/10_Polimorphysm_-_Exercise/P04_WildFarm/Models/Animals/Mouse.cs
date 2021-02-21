using System;
using System.Collections.Generic;
using System.Text;
using P04_WildFarm.Models.Foods;

namespace P04_WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double weightmult = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return $"Squeak";
        }

        public override ICollection<Type> PrefferedFoods => new List<Type>() {typeof(Vegetable), typeof(Friut)};
        public override double WeightMultipier => weightmult;

        public override string ToString()
        {
            return base.ToString() + $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
