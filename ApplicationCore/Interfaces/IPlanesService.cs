using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.DTOs;

namespace Airlines.ApplicationCore.Interfaces
{
    public interface IPlanesService
    {
        public Task<PlaneDTO> GetById(int id);
        public Task<PlaneFlatDTO> GetFlatById(int id);
        public Task<PlaneOverviewDTO> GetOverviewById(int id);
        public Task<IEnumerable<PlaneOverviewDTO>> GetAll();
        public Task Create(PlaneFlatDTO dto);
        public Task Update(PlaneFlatDTO dto);
        public Task Delete(int id);
        public Task AddFlightClass(int planeId, int travelClassId);
        public Task RemoveFlightClass(int planeId, int travelClassId);
    }
}