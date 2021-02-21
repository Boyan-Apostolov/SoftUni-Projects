using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int k = 1;
            double sum = 0;
            double average = 0;
            bool isExcluded = false;
            int exclusions = 0;

            while (k <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    sum += grade;
                    k++;
                }
                else
                {
                    exclusions++;
                }
                if (exclusions >= 2)
                {

                    isExcluded = true;
                    break;

                }
            }
            
            average = sum / 12;

            if (isExcluded == true)
            {
                Console.WriteLine("{0} has been excluded at {1} grade", name, k);
            }
            else
            {
                Console.WriteLine("{0} graduated. Average grade: {1:F2}", name, average);
            }
        }
    }
}
