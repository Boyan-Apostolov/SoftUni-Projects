using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        //{typeOfVehicle} {model} {color} {horsepower}

        /*
         * Type: {typeOfVehicle}
        Model: {modelOfVehicle}
        Color: {colorOfVehicle}
        Horsepower: {horsepowerOfVehicle}
        */
        static void Main(string[] args)
        {
            double averageCarHorsepower = 0.0;
            double averageTruckHorsepower = 0.0;
            double sumCarPower = 0;
            double sumTruckPower = 0;
            double carCounter = 0;
            double truckCounter = 0;
            List<Vehicle> vehicles = new List<Vehicle>();
            string[] tokens = Console.ReadLine().Split(' ');
            string end = null;
            while (end != "Close the Catalogue")
            {
                while (tokens[0] != "End")
                {




                    string typeOfVehicle = tokens[0];
                    string model = tokens[1];
                    string color = tokens[2];
                    double horsepower = double.Parse(tokens[3]);

                    if (typeOfVehicle == "car")
                    {
                        sumCarPower += double.Parse(tokens[3]);
                        carCounter++;
                    }
                    else if (typeOfVehicle == "truck")
                    {
                        sumTruckPower += double.Parse(tokens[3]);
                        truckCounter++;
                    }

                    Vehicle vehicle = new Vehicle();
                    CultureInfo.InvariantCulture.TextInfo.ToTitleCase(typeOfVehicle);
                    vehicle.TypeOfVehicle = typeOfVehicle;
                    vehicle.Model = model;
                    vehicle.Color = color;
                    vehicle.Horsepower = horsepower;
                    vehicles.Add(vehicle);
                    tokens = Console.ReadLine().Split(' ');

                }

                string modelOf = Console.ReadLine();
                foreach (Vehicle vehicle in vehicles)
                {
                    if (modelOf == vehicle.Model)
                    {
                        Console.WriteLine($"Type: {vehicle.TypeOfVehicle}");
                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
                    }
                }
                end = Console.ReadLine();
            }

            averageCarHorsepower = sumCarPower / carCounter;
            averageTruckHorsepower = sumTruckPower / truckCounter;
            Console.WriteLine($"Cars have average horsepower of: {averageCarHorsepower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsepower:f2}.");
            //{typeOfVehicles} have average horsepower of {averageHorsepower}.
        }
    }

    class Vehicle
    {
        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Horsepower { get; set; }
    }
}
