using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelMergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 64356, 45258, 59391, 60339, 2775, 89024, 41085, 63396, 44852, 11824, 93108, 8951, 6843, 73149, 12300, 74381, 16778, 33946, 59866, 41637, 58993, 5205, 42523, 3 };
            Stopwatch sw = new Stopwatch();
            
            sw.Start();
            var sortedList = Merge_Sort(list);
            sw.Stop();

            Console.WriteLine(string.Join(", ", sortedList));
            Console.WriteLine($"Count of elements: {sortedList.Length}");
            Console.WriteLine(sw.Elapsed);
        }

        public static int[] Merge_Sort(List<int> m)
        {
            if (m.Count <= 1)
            {
                return m.ToArray();
            }

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < m.Count; i++)
            {
                if (i < (m.Count) / 2)
                {
                    left.Add(m[i]);
                }
                else
                {
                    right.Add(m[i]);
                }
            }

            Task.Run(() =>
            {
                left = Merge_Sort(left).ToList();
            }).Wait();

            Task.Run(() =>
            {
                right = Merge_Sort(right).ToList();
            }).Wait();

            var result = Merge(left.ToArray(), right.ToArray());
            return result;

        }

        private static int[] Merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            //
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            //while either array still has an element
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //If item on left array is less than item on right array, add that item to the result array 
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
    }
}
