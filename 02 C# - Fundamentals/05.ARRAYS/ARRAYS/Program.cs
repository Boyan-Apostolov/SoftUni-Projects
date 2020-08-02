using System;

namespace ARRAYS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days;
            days = new string[7] {"Monday", "Tuesday", "Wednesday", "Thursday","Friday","Saturday","Sunday" };
            int number = int.Parse(Console.ReadLine());

            if (number >= 1 && number <= 7)
            {
                
                Console.WriteLine(days[number-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }

        }
    }
}
