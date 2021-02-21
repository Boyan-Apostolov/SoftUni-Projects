using System;

namespace Back_in_30_min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;
            if (minutes>59)
            {
                minutes -= 60;
                hours++;
            }
            if (hours>23)
            {
                hours -= 24;
            }

            Console.WriteLine($"{hours:d1}:{minutes:d2}");
        }
    }
}
