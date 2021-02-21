using System;

namespace Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int input2 = int.Parse(Console.ReadLine());
            int sum = 0;
            if (input2 <= 10)
            {
                for (input2 = input2; input2 <= 10; input2++)
                {
                    sum = input * input2;
                    Console.WriteLine($"{input} X {input2} = {sum}");
                }
            }
            else
            {
                Console.WriteLine($"{input} X {input2} = {input*input2}");
            }
        }
    }
}
