using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Prototype
{
    public class Sandwich : SandwitchPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread,string meat,string cheese,string veggies)
        {
            this.meat = meat;
            this.bread = bread;
            this.cheese = cheese;
            this.veggies = veggies;
        }
        public override SandwitchPrototype Clone()
        {
            string ingredientsStr = this.GetIngreadiantList();
            Console.WriteLine("Cloning sandwich with ingrediens: {0}", ingredientsStr);
            return this.MemberwiseClone() as SandwitchPrototype;
        }

        private string GetIngreadiantList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
