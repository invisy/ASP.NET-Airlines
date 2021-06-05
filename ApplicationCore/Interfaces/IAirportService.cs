using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;

namespace Airlines.ApplicationCore.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<FoundFlightsDTO>> FindFlightInstances(SearchFlightsDTO dto);
        Task<IEnumerable<TravelClassDTO>> GetFlightAvailableTravelClasses(int flightInstanceId);
        Task<IEnumerable<PlaneSeatFlatDTO>> GetFlightFreePlaneSeats(int flightInstanceId, int travelClassId);
    }
}