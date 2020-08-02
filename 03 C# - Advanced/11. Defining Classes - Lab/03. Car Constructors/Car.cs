using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Car_Constructors
{
    class Car
    {
        public Car()
            : this("VW", "Gold", 2026, 200, 10)
        {

        }

        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }


        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
    }
}
