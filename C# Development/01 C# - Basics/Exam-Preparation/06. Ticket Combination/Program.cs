using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Ticket_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int count = 1;
            int prize = 0;

            for (int i = 1; i <= input ; i++)
            {
                for (char symbol1 = 'B'; symbol1 <= 'L'; symbol1++)
                {
                    for (char symbol2 = 'f'; symbol2 >= 'a'; symbol2--)
                    {
                        for (char symbol3 = 'A'; symbol3 <= 'C'; symbol3++)
                        {
                            for (int symbol4 = 1; symbol4 < 10; symbol4++)
                            {
                                for (int symbol5 = 10; symbol5 > 1; symbol5--)
                                {
                                    if (symbol1 % 2 == 0)
                                    {
                                        count++;
                                        
                                    }

                                    if (count == input)
                                    {
                                        prize = symbol1 + symbol2 + symbol3 + symbol4 + symbol5;
                                        Console.WriteLine($"Ticket combination: {symbol1}{symbol2}{symbol3}{symbol4}{symbol5}");
                                        Console.WriteLine($"Prize: {prize} lv.");
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
           
        }
    }
}
