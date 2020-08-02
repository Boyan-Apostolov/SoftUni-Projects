using System;
using System.Text.RegularExpressions;
namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string decryporPattern = @"[star]";
            string pattern = @"@([A-Za-z]+)[^@\-!:>]*:[^@\-!:>]*\d+[^@\-!:>]*![^@\-!:>]*([AD])[^@\-!:>]*![^@\-!:>]*->[^@\-!:>]*\d+";
            RegexOptions decryprorOptions = RegexOptions.IgnoreCase;
            Regex DecryprtorRegex = new Regex(decryporPattern, decryprorOptions);
            Regex decryptedRegex = new Regex(pattern);



            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                MatchCollection decryptoCollection = DecryprtorRegex.Matches(input);
                int count = decryptoCollection.Count;

                string decryptedMessage = string.Empty;

                foreach (char c in input)
                {
                    decryptedMessage += (char)(c - count);
                }

                Match match = decryptedRegex.Match(decryptedMessage);

            }
        }
    }
}
