using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<Planet>
    {
        private readonly List<Planet> models;

        public PlanetRepository()
        {
            this.models = new List<Planet>();
        }

        public IReadOnlyCollection<Planet> Models => this.models.AsReadOnly();

        public void Add(Planet model)
        {
            this.models.Add(model);
        }

        public bool Remove(Planet model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }

        public Planet FindByName(string name)
        {
            return this.models.FirstOrDefault(pr => pr.Name == name);
        }
    }
}
