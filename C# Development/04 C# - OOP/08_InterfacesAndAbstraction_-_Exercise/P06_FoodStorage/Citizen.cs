using System;
using System.Collections.Generic;
using System.Text;

namespace P06_FoodStorage
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; }
        public string Birthdate { get; }
        public string Id { get; }
        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 10;
        }

    }
}
