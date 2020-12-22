using System;
using System.Diagnostics;
using System.Linq;

namespace AsyncChrronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            var chronometer = new Chronometer(sw);

            string input = Console.ReadLine();

            while (input != null)
            {
                switch (input)
                {
                    case "start":
                        chronometer.Start();
                        break;

                    case "stop":
                        chronometer.Stop();
                        break;

                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;

                    case "laps":
                        if (chronometer.Laps.Any())
                        {
                            int counter = 0;
                            foreach (var lap in chronometer.Laps)
                            {
                                Console.WriteLine($"{counter++}. {lap}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Laps: no laps");
                        }

                        break;

                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;

                    case "reset":
                        chronometer.Reset();
                        break;

                    case "exit":
                        break;
                        break;

                }

                input = Console.ReadLine();
            }
        }
    }
}
