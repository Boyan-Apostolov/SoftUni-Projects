using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string firsst = (Console.ReadLine());
            int secnd = int.Parse(Console.ReadLine());
            RepeatString(secnd, firsst);
        }

        static string RepeatString(int repeatCount, string text)
        {
            string returnValue = string.Empty;
            for (int i = 0; i < repeatCount; i++)
            {
                
                Console.Write(returnValue+text);
            }
            return returnValue;
        }
    }
}
