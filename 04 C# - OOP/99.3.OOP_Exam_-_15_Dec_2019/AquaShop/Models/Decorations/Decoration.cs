using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {

        public Decoration(int comfort,decimal orice)
        {
            this.Comfort = comfort;
            this.Price = Price;
        }

        public int Comfort { get; }

        public decimal Price { get; }
    }
}
