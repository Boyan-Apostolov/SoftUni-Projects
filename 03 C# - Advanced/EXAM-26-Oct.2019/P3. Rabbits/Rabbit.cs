using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    public class Rabbit
    {
        private string name;
        private string species;
        private bool availability = true;

        public Rabbit(string name, string species)
        {
            this.Name = name;
            this.Species = species;
        }

        public  string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public bool Available
        {
            get { return availability; }
            set { availability = value; }
        }





        public override string ToString()
        {
            return $"Rabbit ({this.Species}): {this.Name}";
        }
    }
}
