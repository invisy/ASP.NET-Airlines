using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;

namespace Airlines.ApplicationCore.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<FoundFlightsDTO>> FindFlightInstances(SearchFlightsDTO dto);
    }
}