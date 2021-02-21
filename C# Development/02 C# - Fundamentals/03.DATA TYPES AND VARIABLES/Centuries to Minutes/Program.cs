using System;

namespace Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int senturies = int.Parse(Console.ReadLine());
            var years = senturies * 100;
            var months = years * 12;
            int days = (int) (years * 365.2422);
            var hours = days * 24;
            var minutes = hours * 60;
            Console.WriteLine($"{senturies} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");    
        }
    }
}
