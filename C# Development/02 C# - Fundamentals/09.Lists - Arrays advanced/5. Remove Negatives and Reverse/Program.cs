using System;
using System.Linq;
namespace _5._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (i < list.Count && list[i]<0)
                {
                    list.RemoveAt(i--);
                }
            }

            list.Reverse();

            if (list.Count <= 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", list));
            }

        }
    }
}
