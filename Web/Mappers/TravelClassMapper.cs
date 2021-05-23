using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Mappers;
using Airlines.Web.Models.AdminPanel;

namespace Airlines.Web.Mappers
{
    public class TravelClassMapper : GenericMapper<TravelClassDTO, TravelClassViewModel>
    {
        public override TravelClassViewModel Map(TravelClassDTO entity)
        {
            TravelClassViewModel viewModel = new TravelClassViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                ClassPrice = entity.ClassPrice
            };

            return viewModel;
        }

        public override TravelClassDTO Map(TravelClassViewModel viewModel)
        {
            TravelClassDTO dto = new TravelClassDTO
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ClassPrice = viewModel.ClassPrice
            };
            
            return dto;
        }
    }
}