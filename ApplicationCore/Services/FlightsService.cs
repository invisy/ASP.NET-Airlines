using System;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;

namespace Airlines.ApplicationCore.Services
{
    public class FlightsService : IFlightsService
    {
        public Task<FlightInstance> FindFlightInstances(int departureCityId, int incomingCityId, DateTime departureDate, DateTime incomingDate)
        {
            throw new NotImplementedException();
        }
    }
}