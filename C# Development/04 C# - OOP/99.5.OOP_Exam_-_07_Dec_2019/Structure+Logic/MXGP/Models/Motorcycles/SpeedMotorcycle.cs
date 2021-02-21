using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower, 125)
        { //Minimum horsepower is 50 and maximum horsepower is 69.
            if (horsePower > 69 || horsePower < 50)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
            else
            {
                this.HorsePower = horsePower;
            }
        }

        public sealed override int HorsePower { get; protected set; }
    }
}
