using System;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;

namespace Airlines.ApplicationCore.Interfaces
{
    public interface IFlightsService
    {
        Task<FlightInstance> FindFlightInstances(int departureCityId, int incomingCityId, DateTime departureDate, DateTime incomingDate);
    }
}