using System.Collections.Generic;
using System.Linq;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;

namespace Airlines.ApplicationCore.Mappers
{
    public class PlaneOverviewMapper : GenericMapper<Plane, PlaneOverviewDTO>
    {
        public override PlaneOverviewDTO Map(Plane entity)
        {
            PlaneOverviewDTO dto = new PlaneOverviewDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Model = entity.Model,
                TotalSeats = entity.TotalSeats,
                TravelClassesNames = new List<string>(entity.TravelClasses.Select(travelClass => travelClass.Name))
            };

            return dto;
        }
    }
}