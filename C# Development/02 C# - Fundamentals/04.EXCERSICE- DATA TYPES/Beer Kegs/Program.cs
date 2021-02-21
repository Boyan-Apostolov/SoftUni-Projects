using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            int counter = 0;
                double biggestKegVolume = int.MinValue;
                string modelOfBiggestKeg = null;

            while (counter < loops)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > biggestKegVolume)
                {
                    biggestKegVolume = volume;
                    modelOfBiggestKeg = model;
                }
                counter++;
            }

            Console.WriteLine(modelOfBiggestKeg);
        }
    }
}
