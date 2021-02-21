using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            if (!this.models.Contains(model))
            {
                return false;
            }

            this.models.Remove(model);
            return true;
        }

        public IDecoration FindByType(string type)
        {
            foreach (var decoration in this.models)
            {
                if (decoration.GetType().Name == type)
                {
                    return decoration;
                }
            }

            return null;
        }
    }
}
