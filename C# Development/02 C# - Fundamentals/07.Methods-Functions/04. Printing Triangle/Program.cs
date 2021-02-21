using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }

        static void PrintTriangle(int passedValue)
        {
            for (int i = 1; i < passedValue+1; i++)
            {
              
                for (int y = 1; y <= i; y++)
                {
                    Console.Write(y + " ");
                    
                }
                Console.WriteLine();
            }

            for (int i = passedValue -1; i >=1 ; i--)
            {

                for (int y = 1; y <= i; y++)
                {
                    Console.Write(y + " ");

                }
                Console.WriteLine();
            }
        }
    }
}
