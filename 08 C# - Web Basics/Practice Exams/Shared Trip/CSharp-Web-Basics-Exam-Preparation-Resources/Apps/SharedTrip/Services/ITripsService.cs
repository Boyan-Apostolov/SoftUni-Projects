using System;
using System.Collections.Generic;
using System.Text;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        string AddTrip(AddTripViewModel input);

        IEnumerable<TripViewModel> GetAll();

        void AddTripToUser(string userId, string tripId);

        TripViewModel GetTripById(string tripId);
    }
}
