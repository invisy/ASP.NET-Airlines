using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;

namespace Airlines.ApplicationCore.Mappers
{
    public class FoundFlightsMapper : GenericMapper<FlightInstance, FoundFlightsDTO>
    {
        public override FoundFlightsDTO Map(FlightInstance entity)
        {
            FoundFlightsDTO dto = new FoundFlightsDTO()
            {
                Id = entity.Id,
                DepartureCity = entity.Flight.DepartureCity.Name,
                IncomingCity = entity.Flight.IncomingCity.Name,
                DepartureDate = entity.DepartureDate,
                IncomingDate = entity.IncomingDate,
                PlaneName = entity.Flight.Plane.Name,
                PlaneModel = entity.Flight.Plane.Model,
                NumberOfAllPlaces = entity.Flight.Plane.TotalSeats
            };

            return dto;
        }
    }
}