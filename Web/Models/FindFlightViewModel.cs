using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airlines.Web.Models
{
    public class FindFlightViewModel
    {
        public List<SelectListItem> DepartureCities { get; set; }
        public List<SelectListItem> IncomingCities { get; set; }
        public int? SelectedDepartureCityId { get; set; }
        public int? SelectedIncomingCityId { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? IncomingDate { get; set; }
    }
}