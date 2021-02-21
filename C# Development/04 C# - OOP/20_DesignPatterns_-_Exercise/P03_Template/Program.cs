using System;

namespace P03_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();
            Console.WriteLine();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            Console.WriteLine();
            
            WhiteWheat whiteWheat = new WhiteWheat();
            whiteWheat.Make();
            Console.WriteLine();
        }
    }
}
