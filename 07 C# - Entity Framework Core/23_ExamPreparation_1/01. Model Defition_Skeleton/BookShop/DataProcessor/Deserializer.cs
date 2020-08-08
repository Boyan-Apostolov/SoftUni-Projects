using System.Runtime.CompilerServices;
using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
           XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]),new XmlRootAttribute("Books"));

           using (StringReader stringReader = new StringReader(xmlString))
           {
               List<Book> validBooks = new List<Book>();
               ImportBookDto[] bookDtos = (ImportBookDto[])xmlSerializer.Deserialize(stringReader);
               StringBuilder sb = new StringBuilder();

               foreach (var bookDto in bookDtos)
               {
                   if (!IsValid(bookDto))
                   {
                       sb.AppendLine(ErrorMessage);
                       continue;
                   }

                   DateTime publishedOn;
                   bool isDateValid = DateTime.TryParseExact(
                       bookDto.PublishedOn,
                       "MM/dd/yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out publishedOn);

                   if (!isDateValid)
                   {
                       sb.AppendLine(ErrorMessage);
                       continue;
                   }

                   Book validBook = new Book()
                   {
                       Name = bookDto.Name,
                       Genre = (Genre)bookDto.Genre,
                       Price = bookDto.Price,
                       Pages = bookDto.Pages,
                       PublishedOn = publishedOn
                   };

                   validBooks.Add(validBook);
                   sb.AppendLine(string.Format(SuccessfullyImportedBook, validBook.Name, validBook.Price));
               }

               context.Books.AddRange(validBooks);
               context.SaveChanges();

               return sb.ToString().TrimEnd();
           }
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportAuthorDto[] authorDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);
            var validAuthors = new List<Author>();

            foreach (var authorDto in authorDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validAuthors.Any(a=>a.Email == authorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Author author = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone
                };

                foreach (var bookDto in authorDto.Books)
                {
                    if (!bookDto.BookId.HasValue)
                    {
                        continue;
                    }

                    Book book = context.Books.FirstOrDefault(b => b.Id == bookDto.BookId);

                    if (book == null)
                    {
                        continue;
                    }
                    author.AuthorsBooks.Add(new AuthorBook()
                    {
                        Author = author,
                        Book = book
                    });

                }
                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                validAuthors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, (author.FirstName + " " + author.LastName),
                    author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(validAuthors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}