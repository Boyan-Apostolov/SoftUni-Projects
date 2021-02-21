using System;
using System.Collections.Generic;
using System.Linq;
namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            list.Add("First");
            list.Add("Second");

            list[1] = "Test";

            var myStack = new Stack<string>();
            myStack.Push("First");
            myStack.Push("Second");
            myStack.Push("Third");

            var lastAdded = myStack.Pop();

            var doesContain = myStack.Contains("Five");
            var count = myStack.Count;

            Console.WriteLine(lastAdded);

            lastAdded = myStack.Pop();
            Console.WriteLine(lastAdded);

            lastAdded = myStack.Peek();
            Console.WriteLine(lastAdded);

            var mystack = new Stack<int>();

            mystack.Push(10); //Add
            mystack.Push(20); // Add
            mystack.Push(30); // Add

            //Console.WriteLine(mystack.Contains(4));// fasle
            //Console.WriteLine(mystack.Count);     // 3
            //Console.WriteLine(mystack.Pop());    // 30
            //Console.WriteLine(mystack.Count);   // 2
            //Console.WriteLine(mystack.Pop());  // 20

            //int result = 0;
            //var otherresult = mystack.trypop(out result);

            //string text = "some text";
            //int res = 0;
            //var parsed = int.tryparse(text, out res);

            //if (parsed)
            //{
            //    console.writeline(res);
            //}
            //else
            //{
            //    console.writeline("invalid input");
            //}

            //if (mystack.TryPop(out var res2))
            //{
            //    Console.WriteLine(res2);
            //}
            //else
            //{
            //    Console.WriteLine("Stack is empty.");
            //}

            foreach (var number in mystack)
            {
                Console.WriteLine(number);
            }

           
        }
    }
}
