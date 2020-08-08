using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using Cinema.Data.Models;
using Cinema.Data.Models.Enums;
using Cinema.DataProcessor.ImportDto;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var validMovies = new List<Movie>();

            foreach (var movieDto in moviesDtos)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan movieDuration;
                bool isprojecOpenDateValid = TimeSpan.TryParseExact(movieDto.Duration, "g",
                    CultureInfo.InvariantCulture, TimeSpanStyles.None, out movieDuration);

                if (!isprojecOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;
                if (!Enum.TryParse(movieDto.Genre, true, out genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie()
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = movieDuration,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                validMovies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre.ToString(), movie.Rating.ToString("f2")));
            }

            context.Movies.AddRange(validMovies);
            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var validEntities = new List<Hall>();

            var hallsDtos = JsonConvert.DeserializeObject<ImportHallsDto[]>(jsonString);

            foreach (var hallDto in hallsDtos)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (hallDto.Seats < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var hall = new Hall()
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D,
                    Seats = new List<Seat>()
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    var seat = new Seat()
                    {
                        Hall = hall
                    };

                    hall.Seats.Add(seat);
                }

                validEntities.Add(hall);
                bool set = false;

                if (hall.Is4Dx && hall.Is3D && !set)
                {
                    set = true;
                    sb.AppendLine(
                        string.Format(SuccessfulImportHallSeat, hall.Name, "4Dx/3D", hallDto.Seats));

                }
                if (hall.Is4Dx && !set)
                {
                    set = true;
                    sb.AppendLine(
                        string.Format(SuccessfulImportHallSeat, hall.Name, "4Dx", hallDto.Seats));
                }
                if (hall.Is3D && !set)
                {
                    set = true;
                    sb.AppendLine(
                        string.Format(SuccessfulImportHallSeat, hall.Name, "3D", hallDto.Seats));
                }
                if (!set)
                {
                    sb.AppendLine(
                        string.Format(SuccessfulImportHallSeat, hall.Name, "Normal", hallDto.Seats));
                }

            }


            context.Halls.AddRange(validEntities);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var validEntities = new List<Projection>();

            var projectionsDtos = XmlConverter.Deserializer<ImportProjectionDto>(xmlString, "Projections");

            foreach (var projectionDto in projectionsDtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId);
                if (movie == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = context.Halls.FirstOrDefault(x => x.Id == projectionDto.HallId);
                if (hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime movieDate;
                bool isMovuedDateValid = DateTime.TryParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out movieDate);

                if (!isMovuedDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var projection = new Projection()
                {
                    MovieId = movie.Id,
                    HallId = hall.Id,
                    DateTime = movieDate
                };

                validEntities.Add(projection);

                sb.AppendLine($"Successfully imported projection { movie.Title} on {movieDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
            }
            context.Projections.AddRange(validEntities);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        } //ish


        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var customerTickersDtos = XmlConverter.Deserializer<ImportCustomersTicketsDto>(xmlString, "Customers");

            StringBuilder sb = new StringBuilder();

            var validEntities = new List<Customer>();

            foreach (var customerDto in customerTickersDtos)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var customer = new Customer()
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,
                    Tickets = new List<Ticket>()
                };
                //add tickets
                foreach (var ticketDto in customerDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var projection = context.Projections.FirstOrDefault(x => x.Id == ticketDto.ProjectionId);

                    if (projection == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price
                    };
                    customer.Tickets.Add(ticket);
                }

                validEntities.Add(customer);
                sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count}!");

            }

            context.Customers.AddRange(validEntities);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();
            var result = Validator.TryValidateObject(obj, validator, validationResult, true);
            return result;
        }

    }
}