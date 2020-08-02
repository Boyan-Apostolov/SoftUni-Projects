using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Template
{
    public class Sourdough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Sourdough bread!");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough bread! (20 minutes)");
        }
    }
}
