using System;
using System.Dynamic;
using System.Linq;

namespace P04._Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Lake lake = new Lake(stones);
            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
