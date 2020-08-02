using System;
using System.Collections.Generic;
using System.Text;
using P01_Vehicles.Models;

namespace P01_Vehicles.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string type, double fuelQty, double fuelCOnsumpt)
        {
            Vehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQty,fuelCOnsumpt);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelCOnsumpt);
            }

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
