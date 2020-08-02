using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Point_in_Rectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            var xIsIndide = this.TopLeft.X <= point.X && point.X <= this.BottomRight.X;
            var yIsInside = this.BottomRight.Y >= point.Y && point.Y >= this.TopLeft.Y;

            return xIsIndide && yIsInside;
        }

    }
}
