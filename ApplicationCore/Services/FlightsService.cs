using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;
using Airlines.ApplicationCore.Specifications;

namespace Airlines.ApplicationCore.Services
{
    public class FlightsService : IFlightsService
    {
        private readonly IUnitOfWork _uow;
        public FlightsService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public Task<IReadOnlyList<FlightInstance>> FindFlightInstances(int departureCityId, int incomingCityId, DateTime departureDate, DateTime incomingDate)
        {
            var spec = new FindFlightsSpecification(departureCityId, incomingCityId, departureDate, incomingDate);
            IAsyncRepository<int, FlightInstance> flightInstanceRepository = _uow.GetRepository<IAsyncRepository<int, FlightInstance>>();
            
            return flightInstanceRepository.ListAsync(spec);
        }
    }
}