using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] text = Console.ReadLine().Split();

            //foreach (var word in text)
            //{
            //    
            //        if (Char.IsUpper(ch))
            //        {
            //            Console.WriteLine(word);
            //            continue;
            //        }
            //    
            //}

            Func<string, bool> filterUppercase = s => Char.IsUpper(s[0]);

            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(filterUppercase)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
