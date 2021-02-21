using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double BIOLOGIST_DEFAULT_OXYGEN = 70;

        public Biologist(string name) : base(name, BIOLOGIST_DEFAULT_OXYGEN)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= 5;
        }
    }
}
