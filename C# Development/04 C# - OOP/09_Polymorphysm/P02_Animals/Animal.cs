using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; set; }
        public string FavouriteFood { get; set; }
        public virtual string ExplainSelf()
        {
            return string.Format(
                "I am {0} and my favourite food is {1}",
                this.Name,
                this.FavouriteFood);
        }

    }
}
