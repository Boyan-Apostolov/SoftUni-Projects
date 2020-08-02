using System;
using System.Collections.Generic;
using System.Text;
using P04_WildFarm.Models.Foods;

namespace P04_WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double weightMultip = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return $"Meow";
        }

        public override ICollection<Type> PrefferedFoods => new List<Type>() {typeof(Vegetable), typeof(Meat)};
        public override double WeightMultipier => weightMultip;
    }
}
