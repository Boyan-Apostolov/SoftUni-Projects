using System;

namespace Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int sum = 1;
            int counter = 2;
            for (int i = 1; i <= inputNumber; i++)
            {
                if (counter == 2)
                {
                    Console.WriteLine(i);
                    counter = 0; ;
                }
                counter++;
                sum += i;
                
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
