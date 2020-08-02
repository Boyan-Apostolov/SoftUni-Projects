using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue,int maxValue)
        {
            this.ValidateRange(minValue,maxValue);
            this.maxValue = maxValue;
            this.minValue = minValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                int value = (int) obj;
                if (value<this.minValue || value > this.maxValue)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("Cannot validate given data type!");
            }
        }

        private void ValidateRange(int minValue, int maxValue)
        {
            if (minValue>maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}
