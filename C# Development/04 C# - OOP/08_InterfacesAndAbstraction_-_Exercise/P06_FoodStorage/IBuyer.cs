using System;
using System.Collections.Generic;
using System.Text;

namespace P06_FoodStorage
{
    public interface IBuyer
    {
        int Food { get; set; }
        string Name { get; set; }
        abstract void BuyFood();
    }
}
