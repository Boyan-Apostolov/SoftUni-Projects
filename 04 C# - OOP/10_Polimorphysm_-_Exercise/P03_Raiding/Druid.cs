using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Raiding
{
    public class Druid : BaseHero
    {
        private const int power = 80;
        public Druid(string name) :base(name, power)
        {
        }
        public override string CastAbility()
        {
            return $"Druid - {this.Name} healed for {this.Power}";
        }
    }
}
