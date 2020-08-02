using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Template
{
    class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for 12-gain bread!");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-grain bread! (25 minutes)");
        }
    }
}
