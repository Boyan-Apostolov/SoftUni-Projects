using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());

            if (command == "+")
            {
                Console.WriteLine(a + b);
            }
            else if (command == "*")
            {
                Console.WriteLine(a * b);
            }
            else if (command == "-")
            {
                Console.WriteLine(a - b);
            }
            else if (command == "/")
            {
                Console.WriteLine(a / b);
            }
        }
    }
}
