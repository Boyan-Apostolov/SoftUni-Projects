using System;
using System.Collections.Generic;
using System.Text;

namespace P05._Comparing_Objects
{
    class Person : IComparable<Person>
    {
        public Person(string name,int age,string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        
        public string Name { get; set; }
        public string Town { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person person)
        {
            int result = 1;
            if (person != null)
            {
                result = this.Name.CompareTo(person.Name);

                if (result == 0)
                {
                    result = this.Age.CompareTo(person.Age);

                    if (result == 0)
                    {
                        result = this.Town.CompareTo(person.Town);
                        
                    }
                }
            }

            return result;
        }
    }
}
