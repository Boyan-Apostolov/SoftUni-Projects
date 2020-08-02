using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = "Pesho";
            int age = 20;

            Person Pesho = new Person()
            {
                Name = name,
                Age = age
            };
        }
    }
}
