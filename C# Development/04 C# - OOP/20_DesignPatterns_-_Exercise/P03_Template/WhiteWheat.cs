using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Template
{
    public class WhiteWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gatheting the ingredients for the WhiteWheat bread!");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the WhiteWheat bread! (15 minutes)");
        }
    }
}
