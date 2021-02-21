using System;

namespace EXERCISE__METHODS_FUNCTIONS
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());
            PrintSmallestOfThreeNumbers(numOne,numTwo,numThree);
        }

        static void PrintSmallestOfThreeNumbers(int a, int b, int c)
        {
            int num = 0;
            if (a <b && a<c)
            {
                num = a;
            }
            else if (b<c)
            {
                num = b;
            }
            else
            {
                num = c;
            }
            Console.WriteLine(num);
        }
    }
}
