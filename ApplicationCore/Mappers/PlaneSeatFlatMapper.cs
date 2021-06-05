using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;

namespace Airlines.ApplicationCore.Mappers
{
    public class PlaneSeatFlatMapper : GenericMapper<PlaneSeat, PlaneSeatFlatDTO>
    {
        public override PlaneSeatFlatDTO Map(PlaneSeat entity)
        {
            PlaneSeatFlatDTO dto = new PlaneSeatFlatDTO();
            dto.Id = entity.Id;
            dto.Number = entity.Number;
            
            return dto;
        }
    }
}