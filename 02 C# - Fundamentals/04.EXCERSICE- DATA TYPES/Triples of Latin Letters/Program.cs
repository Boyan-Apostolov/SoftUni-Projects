using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int first = 0; first < n; first++)
            {
                for (int second = 0; second < n; second++)
                {
                    for (int third = 0; third < n; third++)
                    {
                        Console.WriteLine($"{(char)(first + 'a')}{(char)(second + 'a')}{(char)(third + 'a')}");
                    }
                }
            }
        }
    }
}
