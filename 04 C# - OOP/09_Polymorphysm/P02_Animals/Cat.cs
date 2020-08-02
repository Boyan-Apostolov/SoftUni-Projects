using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name,string favFood)
        {
            this.Name = name;
            this.FavouriteFood = favFood;
        }
        public string Name { get; set; }
        public string FavouriteFood { get; set; }
        public override string ExplainSelf()
        {
            return string.Format(
                "I am {0} and my favourite food is {1}",
                this.Name,
                this.FavouriteFood + Environment.NewLine + "MEEOW");
        }
    }
}
