using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Vehicles.Models.Contracts
{
    public interface IRefuilable
    {
        void Refuel(double fuelAmount);
    }
}
