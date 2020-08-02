using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P01_Vehicles.Factories;
using P01_Vehicles.Models;

namespace P01_Vehicles.Core
{
    public class Engine
    {
        private Vehicle car;
        private Vehicle truck;
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            double fuelQuantity = double.Parse(carArgs[1]);
            double fuelConsumption = double.Parse(carArgs[2]);
            Vehicle car = new Car(fuelQuantity, fuelConsumption);

            string[] truckArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string type = truckArgs[0];
            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);
            Vehicle truck = this.vehicleFactory.ProduceVehicle(type, fuelQuantity, fuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand(car, truck);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);

        }

        private static void ProcessCommand(Vehicle car, Vehicle truck)
        {
            string[] cmdArgs = Console.ReadLine().Split().ToArray();
            string commandType = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double arg = double.Parse(cmdArgs[2]);

            if (commandType == "Drive")
            {
                if (vehicleType == "Car")
                {
                    Console.WriteLine(car.Drive(arg));
                }
                else if (vehicleType == "Truck")
                {
                    Console.WriteLine(truck.Drive(arg));
                }
            }
            else if (commandType == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuel(arg);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(arg);
                }
            }
        }
    }
}
