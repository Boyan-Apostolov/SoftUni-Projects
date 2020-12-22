using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Data.SqlClient.Server;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripViewModel model)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (string.IsNullOrEmpty(model.StartPoint))
            {
                return this.Error("Invalid start point.");
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                return this.Error("Invalid end point");
            }

            if (string.IsNullOrEmpty(model.DepartureTime))
            {
                return this.Error("Departure time is required");
            }

            if (DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return this.Error("Invalid departure time, must be in format dd.MM.yyyy HH.mm");
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                return this.Error("Invalid seats count");
            }

            if (string.IsNullOrEmpty(model.Description) || model.Description.Length > 80)
            {
                return this.Error("Invalid description");
            }

            this.tripsService.AddTrip(model);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var trips = this.tripsService.GetAll();
            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var trip = this.tripsService.GetTripById(tripId);
            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            var trip = this.tripsService.GetTripById(tripId);
            if (trip.FreeSeats <= 0)
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }
            this.tripsService.AddTripToUser(userId, tripId);
            return this.Redirect("/Trips/All");
        }
    }
}
