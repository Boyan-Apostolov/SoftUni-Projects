using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                IAstronaut astronaut = astronauts.FirstOrDefault(a => a.CanBreath);

                if (astronaut == null)
                {
                    break;
                }

                while (planet.Items.Count != 0)
                {
                    string item = planet.Items.FirstOrDefault();
                    astronaut.Breath();

                    if (astronaut.CanBreath == false)
                    {
                        break;
                    }

                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }

    }
}
