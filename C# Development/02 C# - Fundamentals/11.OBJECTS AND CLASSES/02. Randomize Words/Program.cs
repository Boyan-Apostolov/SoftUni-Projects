using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();
            string[] wordsArray = words.Split(" ");

            List<string> wordsList = new List<string>();
            wordsList.AddRange(wordsArray);

            Random rnd = new Random();
            int listCount = wordsList.Count;
            while (listCount>1)
            {
                listCount--;
                int randomPosstion = rnd.Next(listCount + 1);
                string valueOfRandomElemrnt = wordsList[randomPosstion];
                wordsList[randomPosstion] = wordsList[listCount];
                wordsList[listCount] = valueOfRandomElemrnt;
                
            }
Console.WriteLine(string.Join(Environment.NewLine,wordsList));
            
        }
    }
}
