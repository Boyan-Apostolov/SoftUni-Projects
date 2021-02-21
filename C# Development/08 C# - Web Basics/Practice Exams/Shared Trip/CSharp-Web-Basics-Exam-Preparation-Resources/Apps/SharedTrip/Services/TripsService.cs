using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string AddTrip(AddTripViewModel input)
        {
            var trip = new Trip()
            {
                StarPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = DateTime.ParseExact(input.DepartureTime,"dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture,DateTimeStyles.None),
                ImagePath = input.ImagePath,
                Seats = input.Seats,
                Description = input.Description
            };
            this.db.Trips.Add(trip);
            this.db.SaveChanges();
            return trip.Id;
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new TripViewModel()
            {
                Id = x.Id,
                StartPoint = x.StarPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Seats = x.Seats,
                UsersCount = x.UserTrips.Count
            }).ToList();
            return trips;
        }

        public void AddTripToUser(string userId, string tripId)
        {
            var trip = this.GetTripById(tripId);

            if (trip.FreeSeats <= 0)
            {
                return;
            }
            if (this.db.UserTrips.Any(x=>x.TripId == tripId && x.UserId == userId))
            {
                return;
            }
            var userTrip = new UserTrip()
            {
                UserId = userId,
                TripId = tripId
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public TripViewModel GetTripById(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new TripViewModel()
                {
                    Id = x.Id,
                    StartPoint = x.StarPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats,
                    UsersCount = x.UserTrips.Count,
                    Description = x.Description,
                    ImagePath = x.ImagePath
                }).FirstOrDefault();
            return trip;
        }
    }
}
