using System;
using System.Collections.Generic;
using System.Text;
using P04_WildFarm.Models.Foods.Contracts;

namespace P04_WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string ProduceSound();
        void Feed(IFood food);
    }
}
