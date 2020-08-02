using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ");
            int sum = GetStringsSum(strings[0], strings[1]);
            Console.WriteLine(sum);
        }

        private static int GetStringsSum(string strOne, string strTwo)
        {
            int sum = 0;
            int minLength = Math.Min(strOne.Length, strTwo.Length);
            for (int i = 0; i < minLength; i++)
            {
                sum += strOne[i] * strTwo[i];
            }

            string longestStr = strOne;

            if (longestStr.Length < strTwo.Length)
            {
                longestStr = strTwo;
            }

            for (int i = minLength; i < longestStr.Length; i++)
            {
                sum += longestStr[i];
            }

            return sum;
        }
    }
}
