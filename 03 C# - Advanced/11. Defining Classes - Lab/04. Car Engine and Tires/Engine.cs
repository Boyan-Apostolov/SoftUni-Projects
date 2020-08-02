using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Car_Engine_and_Tires
{
    class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePOwer = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
        public int HorsePOwer { get; set; }

        public double CubicCapacity { get; set; }


    }
}
