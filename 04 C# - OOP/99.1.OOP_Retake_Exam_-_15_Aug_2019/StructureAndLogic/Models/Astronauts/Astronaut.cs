using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private Backpack bag;
        public Astronaut(string name,double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Astronaut name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => CanBreathe();

        public IBag Bag => this.bag;

        public virtual void Breath()
        {
            this.Oxygen -= 10;
        }

        private bool CanBreathe()
        {
            if (this.oxygen>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
