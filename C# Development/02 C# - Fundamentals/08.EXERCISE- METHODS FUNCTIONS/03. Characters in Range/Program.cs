using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            PrintCHaractersInRange(first, second);
        }

        static void PrintCHaractersInRange(char firstChar, char secondChar)
        {
            if (firstChar>secondChar)
            {
                char temp = firstChar;
                firstChar = secondChar;
                secondChar = temp;
            }

            for (int i = firstChar +1; i < secondChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
