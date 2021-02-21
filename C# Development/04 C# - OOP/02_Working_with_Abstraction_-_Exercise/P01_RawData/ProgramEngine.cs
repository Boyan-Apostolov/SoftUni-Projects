﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class ProgramEngine
    {
        private readonly List<Car> cars;
        private List<Tire> tires = new List<Tire>();
        public ProgramEngine()
        {
            this.cars = new List<Car>();
            this.tires = new List<Tire>();
        }


        public void Run()
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            ParseInput(lines);
            PrintOutput();
        }

        private void PrintOutput()
        {
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(y => y.Pressure < 1))
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private void ParseInput(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);



                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                Engine engine = CreateEngine(engineSpeed, enginePower);
                Cargo cargo = CreateCargo(cargoWeight, cargoType);
                ReadTires(parameters);
                Car car = CreateCar(model, engine, cargo, this.tires);
                this.cars.Add(car);

            }
        }

        private void ReadTires(string[] parameters)
        {
            for (int j = 5; j <= 12; j += 2)
            {
                double currentTirePressure = double.Parse(parameters[j]);
                int currentTireAge = int.Parse(parameters[j + 1]);
                Tire currentTire = CreateTire(currentTireAge, currentTirePressure);
                tires.Add(currentTire);
            }
        }

        private Engine CreateEngine(int speed, int power)
        {
            Engine engine = new Engine(speed, power);
            return engine;
        }
        private Cargo CreateCargo(int weight, string type)
        {
            Cargo cargo = new Cargo(weight, type);
            return cargo;
        }
        private Tire CreateTire(int age, double pressure)
        {
            Tire tire = new Tire(age, pressure);
            return tire;
        }
        private Car CreateCar(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Car car = new Car(model, engine, cargo, tires.ToArray());
            return car;
        }
    }
}
