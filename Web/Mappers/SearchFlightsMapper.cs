using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Mappers;
using Airlines.Web.Models;

namespace Airlines.Web.Mappers
{
    public class SearchFlightsMapper : GenericMapper<SearchFlightsDTO, SearchFlightsViewModel>
    {
        public override SearchFlightsDTO Map(SearchFlightsViewModel vm)
        {
            SearchFlightsDTO dto = new SearchFlightsDTO()
            {
                DepartureDate = vm.DepartureDate,
                IncomingDate = vm.IncomingDate,
                IncomingCityId = vm.SelectedIncomingCityId,
                DepartureCityId = vm.SelectedDepartureCityId
            };

            return dto;
        }
    }
}