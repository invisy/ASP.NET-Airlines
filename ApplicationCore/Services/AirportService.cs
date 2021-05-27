using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;
using Airlines.ApplicationCore.Specifications;

namespace Airlines.ApplicationCore.Services
{
    public class AirportService : IAirportService
    {
        private readonly IUnitOfWork _uow;
        private IMapper<FlightInstance, FoundFlightsDTO> _foundFlightsMapper;
        
        public AirportService(IUnitOfWork uow, IMapper<FlightInstance, FoundFlightsDTO> foundFlightsMapper)
        {
            _uow = uow;
            _foundFlightsMapper = foundFlightsMapper;
        }
        
        public async Task<IEnumerable<FoundFlightsDTO>> FindFlightInstances(SearchFlightsDTO dto)
        {
            var spec = new FindFlightsSpecification(dto.DepartureCityId, dto.IncomingCityId, dto.DepartureDate, dto.IncomingDate);
            IAsyncRepository<int, FlightInstance> flightInstanceRepository = _uow.GetRepository<IAsyncRepository<int, FlightInstance>>();

            IEnumerable<FoundFlightsDTO> flights = _foundFlightsMapper.Map(await flightInstanceRepository.ListAsync(spec));
            
            return flights;
        }
    }
}