using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            var stack = new Stack<string>();
            stack.Push(sb.ToString());

            for (int i = 0; i < operations; i++)
            {
                string[] commandArgs = Console.ReadLine().Split().ToArray();

                switch (commandArgs[0])
                {
                    case "1":
                        sb.Append(commandArgs[1]);
                        stack.Push(sb.ToString());
                        break;

                    case "2":
                        int length = int.Parse(commandArgs[1]);
                        sb.Remove(sb.Length - length, length);
                        stack.Push(sb.ToString());
                        break;

                    case "3":
                        int index = int.Parse(commandArgs[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;

                    case "4":
                        stack.Pop();
                        sb = new StringBuilder();
                        sb.Append(stack.Peek());
                        break;
                }
            }
        }
    }
}
