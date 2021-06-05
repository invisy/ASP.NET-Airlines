using System;
using System.Collections.Generic;

namespace Airlines.ApplicationCore.Entities
{
    public class Flight : BaseEntity<int>
    {
        public City DepartureCity { get; private set; }
        public int DepartureCityId { get; private set; }
        public City IncomingCity { get; private set; }
        public int IncomingCityId { get; private set; }
        public float FlightPrice { get; private set; }
        public Plane Plane { get; private set; }
        public int PlaneId { get; set; }

        public Flight() { }
        
        public Flight(City departureCity, City incomingCity, float flightPrice, Plane plane)
        {
            this.DepartureCity = departureCity;
            this.IncomingCity = incomingCity;
            this.FlightPrice = flightPrice;
            this.Plane = plane;
        }

        public void UpdateFlightPrice(float flightPrice)
        {
            if (flightPrice is > 1000000 or < 0)
                throw new ArgumentOutOfRangeException(nameof(flightPrice));
            FlightPrice = flightPrice;
        }
    }
}