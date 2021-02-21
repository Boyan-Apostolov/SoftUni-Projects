using System;

namespace Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            int counter = 0;
            int sum = 0;
            char letter ;
            while (true)
            {
                if (counter == loops)
                {
                    break;
                }

                letter = char.Parse(Console.ReadLine());
                sum += (char)letter;
                counter++;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
