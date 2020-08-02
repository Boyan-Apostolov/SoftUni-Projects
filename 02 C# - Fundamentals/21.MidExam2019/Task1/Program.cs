using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorker = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            double cometerBiscuitsPer30Days = int.Parse(Console.ReadLine());
            double biscuits = 0;
            double difference = 0;
            int day = 1;
            while (day <= 30)
            {



                if (day % 3 == 0)
                {
                    biscuits += Math.Floor((biscuitsPerWorker * 0.75) * workers);

                }
                else
                {
                    biscuits += biscuitsPerWorker * workers;
                }

                day++;
            }
            difference = biscuits - cometerBiscuitsPer30Days;
            double percentage = (difference / cometerBiscuitsPer30Days) * 100;
            Console.WriteLine($"You have produced {biscuits} biscuits for the past month.");

            if (biscuits > cometerBiscuitsPer30Days)
            {
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {Math.Abs(percentage):f2} percent less biscuits.");
            }


        }
    }
}
