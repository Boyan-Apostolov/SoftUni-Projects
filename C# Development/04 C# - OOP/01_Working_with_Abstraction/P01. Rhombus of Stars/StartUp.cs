using System;

namespace P01._Rhombus_of_Stars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            for (int stCount = 1; stCount <= size; stCount++)
            { PrintRow(size, stCount); }

            for (int stCount = size - 1; stCount >= 1; stCount--)
            { PrintRow(size, stCount); }
        }

        static void PrintRow(int figureSize, int starCount)

        {

            for (int i = 0; i < figureSize - starCount; i++)

                Console.Write(" ");

            for (int col = 1; col < starCount; col++)

                Console.Write("* ");

            Console.WriteLine("*");

        }
    }
}
