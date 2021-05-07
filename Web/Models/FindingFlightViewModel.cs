using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airlines.Web.Models
{
    public class FindingFlightViewModel
    {
        public List<SelectListItem> DepartureCities { get; set; }
        public List<SelectListItem> IncomingCities { get; set; }
        [Display(Name = "Місто відправлення")]
        public int? SelectedDepartureCityId { get; set; }
        [Display(Name = "Місто прибуття")]
        public int? SelectedIncomingCityId { get; set; }
        [Display(Name = "Дата відправлення")]
        public DateTime? DepartureDate { get; set; }
        [Display(Name = "Дата прибуття")]
        public DateTime? IncomingDate { get; set; }
    }
}