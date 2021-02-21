using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Space_Station_Recruitment
{
    public class Astronaut
    {
        public Astronaut(string name , int age , string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Astronaut: {this.Name}, {this.Age} ({this.Country})";
        }
    }
}
