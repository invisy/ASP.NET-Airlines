using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;

namespace Airlines.ApplicationCore.Mappers
{
    public class TravelClassMapper : GenericMapper<TravelClass, TravelClassDTO>
    {
        public override TravelClassDTO Map(TravelClass entity)
        {
            TravelClassDTO dto = new TravelClassDTO();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.ClassPrice = entity.ClassPrice;
            
            return dto;
        }
    }
}