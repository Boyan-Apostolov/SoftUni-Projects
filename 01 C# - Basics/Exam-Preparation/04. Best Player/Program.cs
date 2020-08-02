using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            
            int maxGoals = int.MinValue;
            string winner = "";

            while (command != "END")
            {
                int goals = int.Parse(Console.ReadLine());
                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    winner = command;
                }

                if (maxGoals >= 10)
                {
                    break;
                }
               
                command = Console.ReadLine();
                
            }

            Console.WriteLine($"{winner} is the best player!");

            if (maxGoals >= 3)
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}
