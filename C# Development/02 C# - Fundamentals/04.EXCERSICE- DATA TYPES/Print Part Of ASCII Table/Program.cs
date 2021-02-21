using System;

namespace Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            char symbol = default;
            
            for (int i = start; i <= end; i++)
            {

                string asciiChar = ((char)i).ToString();
                Console.Write(asciiChar + " ");
            }
        }
    }
}

////using System;
 
////public class Program
////{
////    public static void Main()
////    {
////        int startNumber = int.Parse(Console.ReadLine());
////        int stopNumber = int.Parse(Console.ReadLine());

////        for (int i = startNumber; i <= stopNumber; i++)
////        {
////            Console.Write((char)i + " ");

////        }
////        Console.WriteLine();
////    }