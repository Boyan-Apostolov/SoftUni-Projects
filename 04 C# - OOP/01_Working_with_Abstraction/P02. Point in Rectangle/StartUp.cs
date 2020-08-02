using System;
using System.Linq;

namespace P02._Point_in_Rectangle
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] rectangleAngles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var firstPointX = rectangleAngles[0];
            var firstPointY = rectangleAngles[1];

            var secondPointX = rectangleAngles[2];
            var secondPointY = rectangleAngles[3];

            Point point1 = CreateFirstPoint(firstPointX, firstPointY);
            Point point2 = CreateSecondPoint(secondPointX, secondPointY);

            Rectangle rectangle = CreateRectangle(point1, point2);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var x = dimensions[0];
                var y = dimensions[1];
                Point point = new Point(x, y);
                Console.WriteLine(rectangle.Contains(point));
            }
        }

        private static Rectangle CreateRectangle(Point point1, Point point2)
        {
            return new Rectangle(point1, point2);
        }

        private static Point CreateSecondPoint(int secondPointX, int secondPointY)
        {
            return new Point(secondPointX, secondPointY);
        }

        private static Point CreateFirstPoint(int firstPointX, int firstPointY)
        {
            return new Point(firstPointX, firstPointY);
        }
    }
}
