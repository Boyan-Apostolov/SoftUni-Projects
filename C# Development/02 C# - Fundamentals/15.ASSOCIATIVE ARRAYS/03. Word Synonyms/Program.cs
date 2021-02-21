using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace _03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int number = int.Parse(Console.ReadLine());
                var wordSynonims = new Dictionary<string, List<string>>();

                for (int i = 0; i < number; i++)
                {
                    string word = Console.ReadLine();
                    string synonim = Console.ReadLine();

                    if (wordSynonims.ContainsKey(word))
                    {
                        var list = wordSynonims[word];
                        list.Add(synonim);
                    }
                    else
                    {
                        wordSynonims.Add(word, new List<string> { synonim });
                    }

                }
                foreach (var word in wordSynonims)
                {
                    StringBuilder resultTextBuilder = new StringBuilder();
                    resultTextBuilder.Append(word.Key);
                    resultTextBuilder.Append(" - ");

                    for (int i = 0; i < word.Value.Count; i++)
                    {
                        resultTextBuilder.Append(word.Value[i]);

                        if (i != word.Value.Count - 1)
                        {
                            resultTextBuilder.Append(", ");
                        }
                    }
                    Console.WriteLine(resultTextBuilder);
                }

            }
        }
}
