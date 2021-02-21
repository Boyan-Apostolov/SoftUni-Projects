using System;
using System.Linq;
using System.Collections.Generic;
namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] tokens = line.Split(' ');
                string cmd = tokens[0];

                if (cmd == "Delete")
                {
                    int element = int.Parse(tokens[1]);
                    numbers.RemoveAll(el => el == element);  //el -for => bool(el == element)

                }
                else if (cmd == "Insert")
                {
                    int element = int.Parse(tokens[1]);
                    int possition = int.Parse(tokens[2]);
                    numbers.Insert(possition, element);
                }


                line = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
