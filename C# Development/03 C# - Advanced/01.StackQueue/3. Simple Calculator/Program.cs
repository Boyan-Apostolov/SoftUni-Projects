using System;
using System.Collections.Generic;
using System.Linq;
namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var result = new Stack<string>(input.Reverse());

            while (result.Count > 1)
            {
                var firstNumber = int.Parse(result.Pop());
                var operation = result.Pop();
                var secondNUmber = int.Parse(result.Pop());

                var tempres = 0;
                switch (operation)
                {
                    case "+":
                        tempres = firstNumber + secondNUmber;
                        break;

                    case "-":
                        tempres = firstNumber - secondNUmber;
                        break;
                }

                result.Push(tempres.ToString());

            }

            Console.WriteLine(result.Pop());
        }
    }
}
