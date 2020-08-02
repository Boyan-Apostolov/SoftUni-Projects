using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = 0;
            int[] array= new int[n];
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());
                array[i] = number;
                sum += number;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
