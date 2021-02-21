using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Raiding
{
    public class Paladin : BaseHero
    {
        private const int power = 100;
        public Paladin(string name) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"Paladin - {this.Name} healed for {this.Power}";
        }
    }
}
