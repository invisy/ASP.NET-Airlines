using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airlines.Web.Models
{
    public class SearchFlightsViewModel
    {
        public SelectList DepartureCities { get; set; }
        public SelectList IncomingCities { get; set; }
        [Display(Name = "Місто відправлення")]
        public int SelectedDepartureCityId { get; set; }
        [Display(Name = "Місто прибуття")]
        public int SelectedIncomingCityId { get; set; }
        [Display(Name = "Дата відправлення")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; } = DateTime.Now;
        [Display(Name = "Дата прибуття")]
        [DataType(DataType.Date)]
        public DateTime IncomingDate { get; set; } = DateTime.Now;
    }
}