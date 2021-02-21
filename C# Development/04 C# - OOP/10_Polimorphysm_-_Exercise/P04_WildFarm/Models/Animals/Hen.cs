using System;
using System.Collections.Generic;
using System.Text;
using P04_WildFarm.Models.Foods;

namespace P04_WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double weightMultip = 0.35;
        public Hen(string name, double weight, double wing) : base(name, weight, wing)
        {
        }

        public override string ProduceSound()
        {
            return $"Cluck"; 
        }

        public override ICollection<Type> PrefferedFoods => new List<Type>()
            {typeof(Vegetable), typeof(Friut), typeof(Meat), typeof(Seeds)};
        public override double WeightMultipier => weightMultip;
    }
}
