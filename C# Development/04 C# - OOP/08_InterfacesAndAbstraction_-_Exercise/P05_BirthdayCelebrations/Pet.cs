using System;
using System.Collections.Generic;
using System.Text;

namespace P04_BorderControl
{
    class Pet : IPet
    {
        public Pet(string name,string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; }
        public string Birthdate { get; }
    }
}
