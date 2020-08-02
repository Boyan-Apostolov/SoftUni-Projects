using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = null;

            while ((input = Console.ReadLine()) != "END")
            {
                bool isPalindrome = IsPalindrome(input);
                Console.WriteLine(isPalindrome.ToString().ToLower());
            }
        }

        static bool IsPalindrome(string num)
        {
            bool isPalindrome = true;
            int length = num.Length;
            for (int i = 0; i < length / 2; i++)
            {
                int backwardIndex = length -1 -i;
                if (num[i] != num[backwardIndex])
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }
    }
}
