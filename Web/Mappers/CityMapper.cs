using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Mappers;
using Airlines.Web.Models.AdminPanel;

namespace Airlines.Web.Mappers
{
    public class CityMapper : GenericMapper<CityDTO, CityViewModel>
    {
        public override CityViewModel Map(CityDTO dto)
        {
            CityViewModel viewModel = new CityViewModel()
            {
                Id = dto.Id,
                Name = dto.Name
            };

            return viewModel;
        }

        public override CityDTO Map(CityViewModel viewModel)
        {
            CityDTO dto = new CityDTO
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };

            return dto;
        }
    }
}