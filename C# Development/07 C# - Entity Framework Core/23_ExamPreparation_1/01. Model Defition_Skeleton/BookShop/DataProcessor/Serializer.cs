﻿using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ExportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var mostCraziestAuthors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                        .OrderByDescending(ab => ab.Book.Price)
                        .Select(ab => new
                        {
                            BookName = ab.Book.Name,
                            BookPrice = ab.Book.Price.ToString("f2")
                        })
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Length)
                .ThenBy(a => a.AuthorName)
                .ToArray();
            string json = JsonConvert.SerializeObject(mostCraziestAuthors, Formatting.Indented);
            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            ExportBookDto[] books = context
                .Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Take(10)
                .Select(b => new ExportBookDto()
                {
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d",CultureInfo.InvariantCulture),
                    Pages = b.Pages
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBookDto[]), new XmlRootAttribute("Books"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty,string.Empty);

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter,books, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}