using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            int current = 0;
            for (int i = 0; i < n; i++)
            {
                current = int.Parse(Console.ReadLine());
                sum1 += current;
            }
            for (int i = 0; i < n; i++)
            {
                current = int.Parse(Console.ReadLine());
                sum2 += current;
            }
            if (sum1 == sum2)
            {
                Console.WriteLine("Yes, sum = {0}",sum2);
            }
            else
            {
                Console.WriteLine("No, diff = {0}",Math.Abs(sum1-sum2));
            }
        }
    }
}
