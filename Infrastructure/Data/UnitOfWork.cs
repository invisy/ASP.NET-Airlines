using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;

namespace Airlines.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AirlinesContext _context;
        private readonly Dictionary<Type, IRepository> _repositories = new Dictionary<Type, IRepository>();

        public UnitOfWork(AirlinesContext context, IAsyncRepository<int, FlightInstance> flightInstRepository, 
            IAsyncRepository<int, City> cityRepository, IAsyncRepository<int, TravelClass> travelClassRepository,
            IAsyncRepository<int, Plane> planeRepository, IAsyncRepository<int, Ticket> ticketRepository, 
            IAsyncRepository<int, PlaneSeat> planeSeatRepository)
        {
            _context = context;
            _repositories.Add(typeof(IAsyncRepository<int, FlightInstance>), flightInstRepository);
            _repositories.Add(typeof(IAsyncRepository<int, City>), cityRepository);
            _repositories.Add(typeof(IAsyncRepository<int, TravelClass>), travelClassRepository);
            _repositories.Add(typeof(IAsyncRepository<int, Plane>), planeRepository);
            _repositories.Add(typeof(IAsyncRepository<int, Ticket>), ticketRepository);
            _repositories.Add(typeof(IAsyncRepository<int, PlaneSeat>), planeSeatRepository);
        }
        
        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            if (!_repositories.ContainsKey(typeof(TRepository)))
                throw new ArgumentException("Repository does not exist!");
                
            return (TRepository)_repositories[typeof(TRepository)];
        }

        public async Task<bool> SaveChanges()
        {
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}