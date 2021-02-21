using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Car_Extension
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            var neededFuel = distance * this.FuelConsumption;
            var canContinue = this.FuelQuantity - (neededFuel) >= 0 ;

            if (canContinue)
            {
                this.FuelQuantity -= (neededFuel);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            //"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L"
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L";
        }
    }
}
