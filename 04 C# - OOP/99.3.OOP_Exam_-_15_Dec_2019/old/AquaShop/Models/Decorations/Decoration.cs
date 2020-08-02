using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        public Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }

        public int Comfort
        {
            get => this.comfort;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.comfort = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.price = value;
            }
        }
    }
}
