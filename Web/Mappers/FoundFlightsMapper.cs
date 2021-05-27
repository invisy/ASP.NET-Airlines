using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Mappers;
using Airlines.Web.Models;

namespace Airlines.Web.Mappers
{
    public class FoundFlightsMapper : GenericMapper<FoundFlightsDTO, FoundFlightsViewModel>
    {
        public override FoundFlightsViewModel Map(FoundFlightsDTO dto)
        {
            FoundFlightsViewModel vm = new FoundFlightsViewModel()
            {
                Id = dto.Id,
                DepartureCity = dto.DepartureCity,
                IncomingCity = dto.IncomingCity,
                DepartureDate = dto.DepartureDate,
                IncomingDate = dto.IncomingDate,
                PlaneName = dto.PlaneName,
                PlaneModel = dto.PlaneModel,
                NumberOfAllPlaces = dto.NumberOfAllPlaces
            };

            return vm;
        }
    }
}