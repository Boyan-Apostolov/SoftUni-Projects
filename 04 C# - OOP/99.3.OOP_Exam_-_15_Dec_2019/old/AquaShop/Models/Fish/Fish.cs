using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private int size;
        private decimal price;

        public Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public string Species
        {
            get => this.species;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }

                this.species = value;
            }
        }

        public int Size { get; set; }

        public decimal Price
        {
            get => this.price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }

                this.price = value;
            }
        }

        public virtual void Eat()
        {
        }
    }
}
