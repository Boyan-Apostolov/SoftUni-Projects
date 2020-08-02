using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius { get; set; }

        public override double CalculatePerimeter()
        {
            double pi = Math.PI;
            double area = 2* pi * this.Radius;
            return area;
        }

        public override double CalculateArea()
        {
            double pi = Math.PI;
            double area = pi * (this.Radius * this.Radius);
            return area;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
