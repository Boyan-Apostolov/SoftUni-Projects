using System;

namespace Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string firse = Console.ReadLine();
            string last = Console.ReadLine();
            string delim = Console.ReadLine();
            string result = firse + delim + last;
            Console.WriteLine(result);
        }
    }
}
 