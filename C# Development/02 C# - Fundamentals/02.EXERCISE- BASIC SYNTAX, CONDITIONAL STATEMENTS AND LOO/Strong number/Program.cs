using System;

namespace Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n, n1, s1 = 0, j;
            int fact;



            /* If sum of factorial of digits is equal to original number then it is Strong number */


            n = Convert.ToInt32(Console.ReadLine());
            n1 = n;

            for (j = n; j > 0; j = j / 10)
            {

                fact = 1;
                for (i = 1; i <= j % 10; i++)
                {
                    fact = fact * i;
                }
                s1 = s1 + fact;

            }

            if (s1 == n1)
            {
                Console.Write("yes", n1);
            }
            else
            {
                Console.Write("no", n1);
            }
        }
    }
}
