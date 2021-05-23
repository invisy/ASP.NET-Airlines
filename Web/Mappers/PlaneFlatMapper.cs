using System.Collections.Generic;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Mappers;
using Airlines.Web.Models.AdminPanel;

namespace Airlines.Web.Mappers
{
    public class PlaneFlatMapper : GenericMapper<PlaneFlatDTO, PlaneFlatViewModel>
    {
        public override PlaneFlatViewModel Map(PlaneFlatDTO dto)
        {
            PlaneFlatViewModel viewModel = new PlaneFlatViewModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Model = dto.Model,
                TotalSeats = dto.TotalSeats
            };

            return viewModel;
        }

        public override PlaneFlatDTO Map(PlaneFlatViewModel viewModel)
        {
            PlaneFlatDTO dto = new PlaneFlatDTO
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Model = viewModel.Model,
                TotalSeats = viewModel.TotalSeats
            };

            return dto;
        }
    }
}