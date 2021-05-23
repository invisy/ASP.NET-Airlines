using System.Collections.Generic;
using System.Linq;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;

namespace Airlines.ApplicationCore.Mappers
{
    public class PlaneFlatMapper : GenericMapper<Plane, PlaneFlatDTO>
    {
        public override PlaneFlatDTO Map(Plane entity)
        {
            PlaneFlatDTO dto = new PlaneFlatDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Model = entity.Model,
                TotalSeats = entity.TotalSeats
            };

            return dto;
        }
    }
}