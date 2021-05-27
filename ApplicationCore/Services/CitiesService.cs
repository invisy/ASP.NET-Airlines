using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Exceptions;
using Airlines.ApplicationCore.Interfaces;

namespace Airlines.ApplicationCore.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAsyncRepository<int, City> _repository;
        private readonly IMapper<City, CityDTO> _mapper;
        
        public CitiesService(IUnitOfWork uow, IMapper<City, CityDTO> mapper)
        {
            _uow = uow;
            _repository = _uow.GetRepository<IAsyncRepository<int, City>>();
            _mapper = mapper;
        }
        
        public async Task<CityDTO> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            
            if(entity == null)
                throw new EntityNotFoundException();

            return _mapper.Map(entity);
        }
        
        public async Task<IEnumerable<CityDTO>> GetAll()
        {
            var entities = await _repository.ListAllAsync();
            return _mapper.Map(entities);
        }
        
        public async Task Create(CityDTO dto)
        {
            City city = new City(dto.Name);
            await _repository.AddAsync(city);
            await _uow.SaveChanges();
        }
        
        public async Task Update(CityDTO dto)
        {
            City city = await _repository.GetByIdAsync(dto.Id);
            
            if(city == null)
                throw new EntityNotFoundException();
            
            city.UpdateName(dto.Name);
            await _repository.UpdateAsync(city);
            await _uow.SaveChanges();
        }
        
        public async Task Delete(int id)
        {
            City city = await _repository.GetByIdAsync(id);
            if(city == null)
                throw new EntityNotFoundException();
            _repository.Delete(city);
            await _uow.SaveChanges();
        }
    }
}