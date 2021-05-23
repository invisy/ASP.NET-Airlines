using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Exceptions;
using Airlines.ApplicationCore.Interfaces;
using Airlines.ApplicationCore.Specifications;

namespace Airlines.ApplicationCore.Services
{
    public class PlanesService : IPlanesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAsyncRepository<int, Plane> _repository;
        private readonly IAsyncRepository<int, TravelClass> _travelClassRepository;
        private readonly IMapper<Plane, PlaneOverviewDTO> _planeOverviewMapper;
        private readonly IMapper<Plane, PlaneDTO> _planeMapper;
        private readonly IMapper<Plane, PlaneFlatDTO> _planeFlatMapper;

        public PlanesService(IUnitOfWork uow, 
            IMapper<Plane, PlaneDTO> planeMapper, 
            IMapper<Plane, PlaneOverviewDTO> planeOverviewMapper,
            IMapper<Plane, PlaneFlatDTO> planeFlatMapper)
        {
            _uow = uow;
            _repository = _uow.GetRepository<IAsyncRepository<int, Plane>>();
            _travelClassRepository = _uow.GetRepository<IAsyncRepository<int,TravelClass>>();
            _planeOverviewMapper = planeOverviewMapper;
            _planeMapper = planeMapper;
            _planeFlatMapper = planeFlatMapper;
        }
        
        public async Task<PlaneDTO> GetById(int id)
        {
            var planeSpec = new PlaneWithTravelClassesSpecification(id);
            var entity = await _repository.FirstOrDefaultAsync(planeSpec);
            if(entity == null)
                throw new EntityNotFoundException();

            return _planeMapper.Map(entity);
        }
        
        public async Task<PlaneFlatDTO> GetFlatById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if(entity == null)
                throw new EntityNotFoundException();

            return _planeFlatMapper.Map(entity);
        }
        
        public async Task<PlaneOverviewDTO> GetOverviewById(int id)
        {
            var planeSpec = new PlaneWithTravelClassesSpecification(id);
            var entity = await _repository.FirstOrDefaultAsync(planeSpec);
            if(entity == null)
                throw new EntityNotFoundException();

            return _planeOverviewMapper.Map(entity);
        }
        
        public async Task<IEnumerable<PlaneOverviewDTO>> GetAll()
        {
            var planeSpec = new PlaneWithTravelClassesSpecification();
            var entities = await _repository.ListAsync(planeSpec);

            return _planeOverviewMapper.Map(entities);
        }

        public async Task Create(PlaneFlatDTO dto)
        {
            Plane plane = new Plane(dto.Name, dto.Model, dto.TotalSeats);
            await _repository.AddAsync(plane);
            await _uow.SaveChanges();
        }
        
        public async Task Update(PlaneFlatDTO dto)
        {
            Plane plane = await _repository.GetByIdAsync(dto.Id);
            
            if(plane == null)
                throw new EntityNotFoundException();
            
            plane.Name = dto.Name;
            plane.Model = dto.Model;
            plane.TotalSeats = dto.TotalSeats;
            
            await _repository.UpdateAsync(plane);
            await _uow.SaveChanges();
        }
        
        public async Task Delete(int id)
        {
            Plane plane = await _repository.GetByIdAsync(id);
            if(plane == null)
                throw new EntityNotFoundException();
            _repository.Delete(plane);
            await _uow.SaveChanges();
        }

        public async Task AddFlightClass(int planeId, int travelClassId)
        {
            Plane plane = await _repository.GetByIdAsync(planeId);
            TravelClass travelClass = await _travelClassRepository.GetByIdAsync(travelClassId);
            if(plane == null || travelClass == null)
                throw new EntityNotFoundException();
            plane.AddTravelClass(travelClass);
            await _repository.UpdateAsync(plane);
            await _uow.SaveChanges();
        }
        
        public async Task RemoveFlightClass(int planeId, int travelClassId)
        {
            Plane plane = await _repository.GetByIdAsync(planeId);
            TravelClass travelClass = plane.TravelClasses.FirstOrDefault(x => x.Id == travelClassId);
            if(plane == null || travelClass == null)
                throw new EntityNotFoundException();
            plane.RemoveTravelClass(travelClass);
            await _repository.UpdateAsync(plane);
            await _uow.SaveChanges();
        }
    }
}