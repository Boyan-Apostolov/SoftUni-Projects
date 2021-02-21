﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Raiding
{
    public class Rogue : BaseHero
    {
        private const int power = 80;
        public Rogue(string name) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"Rogue - {this.Name} hit for {this.Power} damage";
        }
    }
}
