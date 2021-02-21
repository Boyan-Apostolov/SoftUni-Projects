using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //List<char> stack = new List<char>();
            //int counter = 0;
            //foreach (char chars in input)
            //{
            //    stack.Add(chars);
            //}

            //int length = input.Length / 2;

            //for (int i = 0; i < stack.Count; i++)
            //{
            //    if (stack[i] == stack[stack.Count-i-1])
            //    {
            //        counter++;
            //    }
            //}
            // "{, [, (, ), ], }
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            var flag = true;

            foreach (char para in input)
            {
                switch (para)
                {
                    case '[':
                    case '(':
                    case '{':
                        stack.Push(para);
                        break;

                    case '}':
                        if (!stack.Any())
                            flag = false;

                        else if (stack.Pop() != '{')
                            flag = false;
                        break;

                    case ')':
                        if (!stack.Any())
                            flag = false;

                        else if (stack.Pop() != '(')
                            flag = false;
                        break;

                    case ']':
                        if (!stack.Any())
                            flag = false;

                        else if (stack.Pop() != '[')
                            flag = false;
                        break;
                }

                if (!flag)
                    break;
            }

            // is balanced?
            Console.WriteLine(flag ? "YES" : "NO");
        }
    }
}
