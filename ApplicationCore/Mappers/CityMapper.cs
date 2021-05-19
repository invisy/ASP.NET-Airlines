using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;

namespace Airlines.ApplicationCore.Mappers
{
    public class CityMapper : GenericMapper<City, CityDTO>
    {
        public override CityDTO Map(City entity)
        {
            CityDTO dto = new CityDTO();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            
            return dto;
        }

        public override City Map(CityDTO dto)
        {
            City entity = new City(dto.Name);
            entity.Id = dto.Id;
            return entity;
        }
    }
}