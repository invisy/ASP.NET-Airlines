using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;

namespace Airlines.ApplicationCore.Interfaces
{
    public interface ICitiesService
    {
        public Task<CityDTO> GetById(int id);
        public Task<IEnumerable<CityDTO>> GetAll();
        public Task Create(string name);
        public Task Update(int id, string name);
        public Task Delete(int id);
    }
}