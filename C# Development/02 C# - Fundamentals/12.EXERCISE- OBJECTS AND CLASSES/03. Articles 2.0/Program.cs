using System;
using System.Collections.Generic;
namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                Article article = new Article(tokens[0], tokens[1], tokens[2]);
                articles.Add(article);
            }

            string criteria = Console.ReadLine();

            switch (criteria)
            {
                case "title":
                    articles.Sort((a1, a2) => a1.Title.CompareTo(a2.Title));
                    break;

                case "content":
                    articles.Sort((a1, a2) => a1.Content.CompareTo(a2.Content));
                    break;

                case "author":
                    articles.Sort((a1, a2) => a1.Author.CompareTo(a2.Author));
                    break;
            }
            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Author = author;
            Content = content;
            Title = title;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            string res = $"{Title} - {Content}: {Author}";
            return res;
        }
    }
}
