using System;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;

        protected Dwarf(string name,int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Instruments = new List<IInstrument>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                this.energy = value > 0 ? value : 0;
            }
        }

        public ICollection<IInstrument> Instruments { get; }

        public virtual void Work()
        {
            this.Energy -= 10;
        }

        public void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }
    }
}
