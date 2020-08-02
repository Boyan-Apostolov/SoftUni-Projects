using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int k = 1;
            double sum = 0;
            double average = 0;

            while (k <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    sum += grade;
                    k++;
                }
            }
            average = sum / 12;
            Console.WriteLine("{0} graduated. Average grade: {1:F2}",name,average);
        }
    }
}
