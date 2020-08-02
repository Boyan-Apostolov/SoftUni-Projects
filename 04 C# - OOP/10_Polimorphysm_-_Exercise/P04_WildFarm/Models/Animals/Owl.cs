using System;
using System.Collections.Generic;
using System.Text;
using P04_WildFarm.Models.Foods;
using P04_WildFarm.Models.Foods.Contracts;

namespace P04_WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double weightMultiplier = 0.25;
        public Owl(string name, double weight, double wing) : base(name, weight, wing)
        {
        }

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }

        public override ICollection<Type> PrefferedFoods => new List<Type>() { typeof(Meat) };
        public override double WeightMultipier => weightMultiplier;
    }
}
