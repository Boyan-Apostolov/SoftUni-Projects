using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        public PowerMotorcycle(string model, int horsePower) : base(model, horsePower, 450)
        { //Minimum horsepower is 70 and maximum horsepower is 100.
            if (horsePower > 100 || horsePower < 70)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,horsePower));
            }
            else
            {
                this.HorsePower = horsePower;
            }
        }

        public sealed override int HorsePower { get; protected set; }
    }
}
