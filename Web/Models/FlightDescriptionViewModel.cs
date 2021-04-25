using System;

namespace Airlines.Web.Models
{
    public class FlightDescriptionViewModel
    {
        public String DepartureCity { get; set; }
        public String IncomingCity { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime IncomingDate { get; set; }
        public int MinimalPrice { get; set; }
        public int PlaneName { get; set; }
        public int PlaneModel { get; set; }
        public int NumberOfAllPlaces { get; set; }
        public int NumberOfFreePlaces { get; set; }
        public bool OrderButtonIsActive { get; set; }
    }
}