using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private ICollection<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => (IReadOnlyCollection<IPresent>) this.models;
        public void Add(IPresent model) => this.models.Add(model);

        public bool Remove(IPresent model) => this.models.Remove(model);

        public IPresent FindByName(string name) => this.models.FirstOrDefault(m => m.Name == name);
    }
}
