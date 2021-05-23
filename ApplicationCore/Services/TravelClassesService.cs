using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Exceptions;
using Airlines.ApplicationCore.Interfaces;

namespace Airlines.ApplicationCore.Services
{
    public class TravelClassesService : ITravelClassesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAsyncRepository<int, TravelClass> _repository;
        private readonly IMapper<TravelClass, TravelClassDTO> _mapper;
        
        public TravelClassesService(IUnitOfWork uow, IMapper<TravelClass, TravelClassDTO> mapper)
        {
            _uow = uow;
            _repository = _uow.GetRepository<IAsyncRepository<int, TravelClass>>();
            _mapper = mapper;
        }
        
        public async Task<TravelClassDTO> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            
            if(entity == null)
                throw new EntityNotFoundException();

            return _mapper.Map(entity);
        }
        
        public async Task<IEnumerable<TravelClassDTO>> GetAll()
        {
            var entities = await _repository.ListAllAsync();
            return _mapper.Map(entities);
        }
        
        public async Task Create(TravelClassDTO dto)
        {
            TravelClass travelClass = new TravelClass(dto.Name, dto.ClassPrice);
            await _repository.AddAsync(travelClass);
            await _uow.SaveChanges();
        }
        
        public async Task Update(TravelClassDTO dto)
        {
            TravelClass travelClass = await _repository.GetByIdAsync(dto.Id);
            
            if(travelClass == null)
                throw new EntityNotFoundException();
            
            travelClass.Name = dto.Name;
            travelClass.ClassPrice = dto.ClassPrice;
            await _repository.UpdateAsync(travelClass);
            await _uow.SaveChanges();
        }
        
        public async Task Delete(int id)
        {
            TravelClass travelClass = await _repository.GetByIdAsync(id);
            if(travelClass == null)
                throw new EntityNotFoundException();
            _repository.Delete(travelClass);
            await _uow.SaveChanges();
        }
    }
}