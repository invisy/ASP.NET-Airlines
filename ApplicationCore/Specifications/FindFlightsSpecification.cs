using System;
using Airlines.ApplicationCore.Entities;
using Ardalis.Specification;

namespace Airlines.ApplicationCore.Specifications
{
    public sealed class FindFlightsSpecification : Specification<FlightInstance>
    {
        public FindFlightsSpecification(int departureCityId, int incomingCityId, DateTime departureDate, DateTime incomingDate) : base()
        {
            Query
                .Where(o => DateTime.Compare(o.DepartureDate.Date, departureDate.Date) == 0 &&
                            DateTime.Compare(o.IncomingDate.Date, incomingDate.Date) == 0 &&
                            o.Flight.DepartureCity.Id == departureCityId &&
                            o.Flight.IncomingCity.Id == incomingCityId)
                .Include(o => o.Flight)
                .ThenInclude(o => o.Plane)
                .Include(o => o.Flight)
                .ThenInclude(o => o.DepartureCity)
                .Include(o => o.Flight)
                .ThenInclude(o => o.IncomingCity);
        }
    }
}