using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages.ColdBeverages
{
    public class ColdBeverage : Beverage
    {
        public ColdBeverage(string name, decimal price, double milims) : base(name, price, milims)
        {
        }
    }
}
