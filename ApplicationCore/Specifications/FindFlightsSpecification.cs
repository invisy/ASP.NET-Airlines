using System;
using Airlines.ApplicationCore.Entities;
using Ardalis.Specification;

namespace Airlines.ApplicationCore.Specifications
{
    public class FindFlightsSpecification : Specification<FlightInstance>
    {
        public FindFlightsSpecification(int departureCityId, int incomingCityId, DateTime departureDate, DateTime incomingDate ) : base()
        {
            Query.Where(o => o.DepartureDate == departureDate && 
                             o.IncomingDate == incomingDate && 
                             o.Flight.DepartureCity.Id == departureCityId && 
                             o.Flight.IncomingCity.Id == incomingCityId)
                .Include(o => o.Flight);
        }
    }
}