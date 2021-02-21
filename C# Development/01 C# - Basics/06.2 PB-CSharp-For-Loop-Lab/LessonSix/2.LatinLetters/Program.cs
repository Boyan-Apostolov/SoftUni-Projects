using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.LatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 'a';
            int endNumber = 'z';
            for (int i = startNumber; i <= endNumber; i++)
            {
                Console.WriteLine((char)i);
            }
        }
    }
}
