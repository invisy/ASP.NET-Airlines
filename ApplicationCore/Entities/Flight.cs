using System;
using System.Collections.Generic;

namespace Airlines.ApplicationCore.Entities
{
    public class Flight : BaseEntity<int>
    {
        public City DepartureCity { get; private set; }
        public City IncomingCity { get; private set; }
        public float FlightPrice { get; private set; }
        public Plane Plane { get; private set; }

        public Flight()
        {
            
        }
        
        public Flight(City departureCity, City incomingCity, float flightPrice, Plane plane)
        {
            this.DepartureCity = departureCity;
            this.IncomingCity = incomingCity;
            this.FlightPrice = flightPrice;
            this.Plane = plane;
        }
    }
}