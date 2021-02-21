using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;
        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public bool Remove(IAstronaut model)
        {
            if (!this.models.Contains(model))
            {
                return false;
            }

            this.models.Remove(model);
            return true;
        }

        public IAstronaut FindByName(string name)
        {
            return this.models.FirstOrDefault(pr => pr.Name == name);
        }
    }
}
