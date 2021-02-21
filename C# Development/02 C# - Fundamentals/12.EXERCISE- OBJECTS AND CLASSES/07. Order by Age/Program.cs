using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string inputTokens = Console.ReadLine();
            while (inputTokens != "End")
            {
                string[] commands = inputTokens.Split(' ');
                string name = commands[0];
                int id = int.Parse(commands[1]);
                int age = int.Parse(commands[2]);

                Person person = new Person();
                person.Name = name;
                person.Id = id;
                person.Age = age;
                people.Add(person);

                inputTokens = Console.ReadLine();
            }
            people = people.OrderBy(s => s.Age).ToList();

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
    }
}
