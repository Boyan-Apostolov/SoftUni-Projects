using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string correctPasswor = null;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                correctPasswor += username[i];
            }

            string password = Console.ReadLine();
            int counter = 1;
            bool isBlocked = false;
            while (password != correctPasswor)
            {
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    isBlocked = true;
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
                counter++;
            }
            if (!isBlocked)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
