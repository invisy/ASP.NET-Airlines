using System.Collections.Generic;
using Airlines.ApplicationCore.Entities;
using Ardalis.Specification;

namespace Airlines.ApplicationCore.Specifications
{
    public sealed class GetFlightTravelClassesSpecification : Specification<FlightInstance, IEnumerable<TravelClass>>
    {
        public GetFlightTravelClassesSpecification(int flightInstanceId)
        {
            Query
                .Select(o => o.Flight.Plane.TravelClasses)
                .Where(o => o.Id == flightInstanceId)
                .Include(o => o.Flight)
                .ThenInclude(o => o.Plane)
                .ThenInclude(o => o.TravelClasses);
        }
    }
}