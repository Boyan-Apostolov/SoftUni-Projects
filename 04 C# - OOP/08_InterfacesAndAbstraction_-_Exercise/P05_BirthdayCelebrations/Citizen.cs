using System;
using System.Collections.Generic;
using System.Text;

namespace P04_BorderControl
{
    public class Citizen : ICitizen, IIdHolder
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Birthdate { get; }
        public string Id { get; }
    }
}
