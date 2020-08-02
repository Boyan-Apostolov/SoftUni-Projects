using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double expenses = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    expenses += headSetPrice;
                }

                if (i % 3 == 0)
                {
                    expenses += mousePrice;
                }

                if (i % 6 == 0)
                {
                    expenses += keyboardPrice;
                }

                if (i % 12 == 0)
                {
                    expenses += displayPrice;
                }
            }
            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
