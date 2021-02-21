﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double additionalConsumptionPerKm = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AdditionalConsumption => additionalConsumptionPerKm;
    }
}
