using System.Collections.Generic;
using System.Linq;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;

namespace Airlines.ApplicationCore.Mappers
{
    public class PlaneMapper : GenericMapper<Plane, PlaneDTO>
    {
        private IMapper<TravelClass, TravelClassDTO> _travelClassMapper;
        
        public PlaneMapper(IMapper<TravelClass, TravelClassDTO> travelClassMapper)
        {
            _travelClassMapper = travelClassMapper;
        }
        
        public override PlaneDTO Map(Plane entity)
        {
            PlaneDTO dto = new PlaneDTO
            {
                Id = entity.Id,
                Model = entity.Model,
                TotalSeats = entity.TotalSeats,
                TravelClasses = new List<TravelClassDTO>(_travelClassMapper.Map(entity.TravelClasses))
            };

            return dto;
        }
    }
}