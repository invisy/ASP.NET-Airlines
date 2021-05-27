using System;

namespace Airlines.ApplicationCore.DTOs
{
    public class SearchFlightsDTO
    {
        public int DepartureCityId { get; set; }
        public int IncomingCityId { get; set; }
        public DateTime DepartureDate { get; set; } 
        public DateTime IncomingDate { get; set; }
    }
}