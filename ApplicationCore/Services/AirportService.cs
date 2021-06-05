using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper<FlightInstance, FoundFlightsDTO> _foundFlightsMapper;
        private readonly IMapper<TravelClass, TravelClassDTO> _travelClassMapper;
        private readonly IMapper<PlaneSeat, PlaneSeatFlatDTO> _planeSeatMapper;

        public AirportService(IUnitOfWork uow, IMapper<FlightInstance, FoundFlightsDTO> foundFlightsMapper, 
            IMapper<TravelClass, TravelClassDTO> travelClassMapper, IMapper<PlaneSeat, PlaneSeatFlatDTO> planeSeatMapper)
        {
            _uow = uow;
            _foundFlightsMapper = foundFlightsMapper;
            _travelClassMapper = travelClassMapper;
            _planeSeatMapper = planeSeatMapper;
        }
        
        public async Task<IEnumerable<FoundFlightsDTO>> FindFlightInstances(SearchFlightsDTO dto)
        {
            IAsyncRepository<int, FlightInstance> flightInstanceRepository = _uow.GetRepository<IAsyncRepository<int, FlightInstance>>();
            var spec = new FindFlightsSpecification(dto.DepartureCityId, dto.IncomingCityId, dto.DepartureDate, dto.IncomingDate);
            
            IEnumerable<FoundFlightsDTO> flights = _foundFlightsMapper.Map(await flightInstanceRepository.ListAsync(spec));
            
            return flights;
        }

        public async Task<IEnumerable<TravelClassDTO>> GetFlightAvailableTravelClasses(int flightInstanceId)
        {
            IAsyncRepository<int, FlightInstance> flightInstanceRepository = _uow.GetRepository<IAsyncRepository<int, FlightInstance>>();
            var spec = new GetFlightTravelClassesSpecification(flightInstanceId);
            var flightInstanceDto = await flightInstanceRepository.FirstOrDefaultAsync(spec);
            
            return _travelClassMapper.Map(flightInstanceDto.Flight.Plane.TravelClasses);
        }
        
        public async Task<IEnumerable<PlaneSeatFlatDTO>> GetFlightFreePlaneSeats(int flightInstanceId, int travelClassId)
        {
            IAsyncRepository<int, PlaneSeat> planeSeatRepository = _uow.GetRepository<IAsyncRepository<int, PlaneSeat>>();
            var spec = new FreePlaneSeatsSpecification(flightInstanceId, travelClassId);
            var planeSeats = await planeSeatRepository.ListAsync(spec);
            
            return _planeSeatMapper.Map(planeSeats);
        }
    }
}