using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price,double milims) : base(name, price)
        {
            this.Milliliters = milims;
        }

        public virtual double Milliliters { get; set; }
    }
}
