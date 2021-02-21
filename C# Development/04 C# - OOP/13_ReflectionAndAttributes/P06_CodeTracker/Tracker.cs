using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P06_CodeTracker
{
    public class Tracker
    {
        
        public static void PrintMethodsByAuthor()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var typesAndAttributes = types.Select(t => new
                {
                    Type = t,
                    Attributes = t.GetCustomAttributes<AuthorAttribute>()
                })
                .Where(a => a.Attributes.Any());

            var result = new Dictionary<string,List<string>>();

            foreach (var typeAndAttributes in typesAndAttributes)
            {
                var type = typeAndAttributes.Type.Name;
                var authors = typeAndAttributes.Attributes.Select(a => a.Name);

                foreach (var author in authors)
                {
                    if (!result.ContainsKey(author))
                    {
                        result[author] = new List<string>();
                    }

                    result[author].Add(type);
                }

                foreach (var author in result)
                {
                    string classes = string.Join(", ", author.Value);
                    Console.WriteLine($"{classes} is written by {author.Key}");
                }
            }

        }
    }
}
