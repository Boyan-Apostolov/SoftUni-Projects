using System;
using System.Collections.Generic;
using System.Text;
using P04_WildFarm.Models.Foods.Contracts;

namespace P04_WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; }
    }
}
