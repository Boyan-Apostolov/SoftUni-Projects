using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P04_WildFarm.Models.Animals;
using P04_WildFarm.Models.Animals.Contracts;
using P04_WildFarm.Models.Foods.Contracts;

namespace P04_WildFarm
{
    public class Engine
    {
        private ICollection<IAnimal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArgs = command.Split().ToArray();
                string[] foodArgs = Console.ReadLine().Split().ToArray();

                string animalType = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);


                IAnimal animal = null;
                if (animalType == "Owl")
                {
                    double wing = double.Parse(animalArgs[3]);
                    animal = new Owl(name, weight, wing);
                }
                else if (animalType == "Hen")
                {
                    double wing = double.Parse(animalArgs[3]);
                    animal = new Hen(name, weight, wing);
                }
                else
                {
                    string livingregion = animalArgs[3];
                    if (animalType == "Dog")
                    {
                        animal = new Dog(name, weight, livingregion);
                    }
                    else if (animalType == "Mouse")
                    {
                        animal = new Mouse(name, weight, livingregion);
                    }
                    else
                    {
                        string breed = animalArgs[4];
                        if (animalType == "Cat")
                        {
                            animal = new Cat(name, weight, livingregion, breed);
                        }
                        else if (animalType == "Tiger")
                        {
                            animal = new Tiger(name, weight, livingregion, breed);
                        }
                    }
                }

                IFood food = this.foodFactory.ProduceFood(foodArgs[0], int.Parse(foodArgs[1]));
                animals.Add(animal);
                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void ProduceAnimal(string animalType, string[] animalArgs, string name, double weight)
        {
            
            
        }
    }
}
