using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;

namespace Airlines.ApplicationCore.Interfaces
{
    public interface ITravelClassesService
    {
        public Task<TravelClassDTO> GetById(int id);
        public Task<IEnumerable<TravelClassDTO>> GetAll();
        public Task Create(TravelClassDTO dto);
        public Task Update(TravelClassDTO dto);
        public Task Delete(int id);
    }
}