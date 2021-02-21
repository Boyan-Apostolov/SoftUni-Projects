using System;

namespace _08.Letters_change_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pairs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach (string pair in pairs)
            {
                char firstLetter = pair[0];
                char lastLetter = pair[^1];

                string numAsString = pair.Substring(1, pair.Length-2);
                double num = int.Parse(numAsString);

                if (char.IsUpper(firstLetter))
                {
                    int possition = firstLetter -64;
                    num /= possition;
                }
                else
                {
                    int possition = firstLetter - 96;
                    num *= possition;
                }

                if (char.IsUpper(lastLetter))
                {
                    int possition = lastLetter - 64;
                    num -= possition;
                }
                else
                {
                    int possition = lastLetter - 96;
                    num += possition;
                }
                sum += num;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
