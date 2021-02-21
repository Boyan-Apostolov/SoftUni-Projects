using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTransactions = int.Parse(Console.ReadLine());
            int k = 0;
            double balance = 0;
            while (numberOfTransactions > k)
            {
                double transaction = double.Parse(Console.ReadLine());
                
                if (transaction < 0)
                {
                    
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                balance = balance + transaction;
                Console.WriteLine("Increase: {0:F2}",transaction);

                k++;
                
            }
            Console.WriteLine("Total: {0:F2}",balance);
        }
    }
}
