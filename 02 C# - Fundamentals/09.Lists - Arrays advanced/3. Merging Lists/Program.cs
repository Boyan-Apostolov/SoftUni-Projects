using System;
using System.Linq;
using System.Collections.Generic;
namespace _3._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var list2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var caunt1 = list1.Count;
            var caunt2 = list2.Count;
            var maxCount = Math.Max(list1.Count, list2.Count);
            int counter = 0;
            List<int> mergedList = new List<int>();

            for (int i = 0; i < maxCount; i++)
            {
                if (i < caunt1)
                {
                    mergedList.Add ( list1[i]);
                    
                }
                
                if (i < caunt2)
                {
                    mergedList.Add ( list2[i]);
                }

                
                
            }
            Console.WriteLine(string.Join(" ", mergedList));
        }
    }
}
