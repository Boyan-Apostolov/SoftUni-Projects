using System;
using System.Linq;
namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {


                string firstNum = arr[0];
                for (int index = 1; index < arr.Length; index++)
                {
                    string cuurentElement = arr[index];
                    arr[index - 1] = cuurentElement;

                }
                arr[arr.Length - 1] = firstNum;
            }
            
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
