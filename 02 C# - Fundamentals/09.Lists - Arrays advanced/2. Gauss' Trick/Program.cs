using System;
using System.Linq;
using System.Collections.Generic;
namespace _2._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var count = list.Count();
            

            for (int i = 0; i < count/2; i++)
            {
                var indexPosition = list[i];
                var indexAtLastPosition = list.Count - 1; // zero based
                var lastPosition = list[indexAtLastPosition];

                // sum the index and current last value
                var sum = indexPosition + lastPosition;

                // assign the summed value to the iteration index position
                list[i] = sum;

                // Remove the item at the last position
                list.RemoveAt(indexAtLastPosition);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
