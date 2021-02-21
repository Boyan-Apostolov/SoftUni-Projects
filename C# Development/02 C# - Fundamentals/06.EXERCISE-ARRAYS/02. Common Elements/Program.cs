using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(" ");
            string[] array2 = Console.ReadLine().Split(" ");

            foreach (string item2 in array2)
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    string element1 = array1[i];
                    if (item2 == element1)
                    {
                        Console.Write(element1+" ");
                        break;
                    }
                }
                
            }
        }
    }
}
