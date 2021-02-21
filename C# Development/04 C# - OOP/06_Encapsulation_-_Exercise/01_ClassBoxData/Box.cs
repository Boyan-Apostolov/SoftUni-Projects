using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ClassBoxData
{
    public class Box
    {
        private const double SIDE_MIN_VALUE = 0;
        private const string INVALID_SIDE_MESSAGE = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value<= SIDE_MIN_VALUE)
                {
                    throw new ArgumentException(string.Format(INVALID_SIDE_MESSAGE,nameof(this.Length)));
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= SIDE_MIN_VALUE)
                {
                    throw new ArgumentException(string.Format(INVALID_SIDE_MESSAGE, nameof(this.Width)));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= SIDE_MIN_VALUE)
                {
                    throw new ArgumentException(string.Format(INVALID_SIDE_MESSAGE, nameof(this.Height)));
                }

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            double surfaceArea = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) +
                                 (2 * this.Width * this.Height);
            return surfaceArea;
        }

        public double CalculateLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return lateralSurfaceArea;
        }

        public double CalculateVolume()
        {
            double volume = this.Length * this.Height * this.Width;
            return volume;
        }
    }
}
