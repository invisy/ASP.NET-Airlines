using System;

namespace Airlines.ApplicationCore.DTOs
{
    public class FoundFlightsDTO
    {
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        public string IncomingCity { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime IncomingDate { get; set; }
        public string PlaneName { get; set; }
        public string PlaneModel { get; set; }
        public int NumberOfAllPlaces { get; set; }
        public int NumberOfFreePlaces { get; set; } = 5;
        public int MinimalPrice { get; set; }
    }
}