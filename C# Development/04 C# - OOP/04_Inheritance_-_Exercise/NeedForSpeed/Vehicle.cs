using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{//•	A constructor that accepts the following parameters: int horsePower, double fuel
    // •	DefaultFuelConsumption – double 
    // •	FuelConsumption – virtual double
    // •	 Fuel – double
    // •	 HorsePower – int
    // •	virtual void Drive(double kilometers)
    // 
    public class Vehicle
    {
        private double fuelconsumpt =1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption
        {
            get => this.fuelconsumpt;
            set => this.fuelconsumpt = value;
        }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers;
        }
    }
}
