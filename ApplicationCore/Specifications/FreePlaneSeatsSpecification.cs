using Airlines.ApplicationCore.Entities;
using Ardalis.Specification;

namespace Airlines.ApplicationCore.Specifications
{
    public sealed class FreePlaneSeatsSpecification : Specification<PlaneSeat>
    {
        public FreePlaneSeatsSpecification(int flightInstanceId, int travelClassId)
        {
            Query
                .Where(o => o.TravelClassId == travelClassId &&
                            o.FlightInstanceId == flightInstanceId &&
                            o.TicketId == null);
        }
    }
}