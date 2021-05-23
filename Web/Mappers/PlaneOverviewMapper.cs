using System.Collections.Generic;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Mappers;
using Airlines.Web.Models.AdminPanel;

namespace Airlines.Web.Mappers
{
    public class PlaneOverviewMapper : GenericMapper<PlaneOverviewDTO, PlaneOverviewViewModel>
    {
        public override PlaneOverviewViewModel Map(PlaneOverviewDTO dto)
        {
            PlaneOverviewViewModel viewModel = new PlaneOverviewViewModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Model = dto.Model,
                TotalSeats = dto.TotalSeats,
                TravelClassesNames = new List<string>(dto.TravelClassesNames)
            };

            return viewModel;
        }

        public override PlaneOverviewDTO Map(PlaneOverviewViewModel viewModel)
        {
            PlaneOverviewDTO dto = new PlaneOverviewDTO
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Model = viewModel.Model,
                TotalSeats = viewModel.TotalSeats,
                TravelClassesNames = new List<string>(viewModel.TravelClassesNames)
            };

            return dto;
        }
    }
}