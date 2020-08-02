using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double width,double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
