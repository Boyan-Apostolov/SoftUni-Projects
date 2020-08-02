using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>(input);

            //foreach (var symbol in input)
            //{
            //    stack.Push(symbol);
            //}

            while (stack.Any())  // stack.count != 0
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
