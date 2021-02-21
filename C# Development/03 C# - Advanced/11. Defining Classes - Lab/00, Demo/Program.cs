using System;

namespace _00__Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object
            //Annonomys Type
            //var cat = new
            //{
            //    Name = "Pesho",
            //    Age = 10
            //};

            //Console.WriteLine(cat.Name); //Pesho

            //class cat()
            var cat = new Cat();
            cat.Name = "ivan";
            cat.Age = 3;

            //var cat = new Cat("Ivan", 5, "Black");

        }
    }
}
