using System;
using System.Collections.Generic;
using System.Text;
using P04_WildFarm.Models.Foods;

namespace P04_WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double weightMultip = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }

        public override ICollection<Type> PrefferedFoods => new List<Type>() {typeof(Meat)};
        public override double WeightMultipier => weightMultip;
    }
}
