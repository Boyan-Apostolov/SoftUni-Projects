using System.Linq;
using Cinema.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;

    using Data;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(y => y.Tickets.Count >= 1))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x=>x.Projections.Sum(y => y.Tickets.Sum(z => z.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(y => y.Tickets.Sum(z => z.Price)).ToString("f2"),
                    Customers = x.Projections.SelectMany(y => y.Tickets).Select(z => new
                        {
                            FirstName = z.Customer.FirstName,
                            LastName = z.Customer.LastName,
                            Balance = z.Customer.Balance.ToString("f2")

                        })
                        .OrderByDescending((m => m.Balance))
                        .ThenBy((m => m.FirstName))
                        .ThenBy((m => m.LastName))
                        .ToArray()
                })
                .Take(10)
                .ToArray();
            var json = JsonConvert.SerializeObject(movies,Formatting.Indented);
            return json;

        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(x => x.Age >= age)
                .OrderByDescending(x=>x.Tickets.Sum(y => y.Price))
                .Take(10)
                .Select(x => new ExportCustomerDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(y => y.Price).ToString("f"),
                    SpentTime = TimeSpan.FromSeconds(x.Tickets.Sum(s => s.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                })
                .ToArray();

            var xml = XmlConverter.Serialize(customers, "Customers");
            return xml;
        }
    }
}