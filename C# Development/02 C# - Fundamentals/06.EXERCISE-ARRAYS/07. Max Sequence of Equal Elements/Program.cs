using System;
using System.Linq;
namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int count = 1;
            int num = array[0];
            int bestCount = 1;
            int bestNum = array[0];
            for (int i = 0; i < array.Length -1; i++)
            {
                int element = array[i];
                int nextNum = array[i + 1];
                if (element == nextNum)
                {
                    count++;
                    
                }
                else
                {
                    count = 1;
                    num = nextNum;
                }

                if (count>bestCount)
                {
                    bestCount = count;
                    bestNum = num;
                }
            }
            for (int i = 0; i < bestCount; i++)
            {
                Console.Write(bestNum+ " ");
            }
        }
    }
}
