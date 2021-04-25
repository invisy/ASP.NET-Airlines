﻿using System;
using System.Collections.Generic;

namespace Airlines.ApplicationCore.Entities
{
    public class FlightInstance
    {
        public DateTime DepartureDate { get; private set; }
        public DateTime IncomingDate { get; private set; }
        public Flight Flight { get; private set; }
        private readonly List<PlaneSeat> _seats = new List<PlaneSeat>();
        public IReadOnlyCollection<PlaneSeat> Seats => _seats.AsReadOnly();
        
        public FlightInstance(DateTime departureDate, DateTime incomingDate, Flight flight)
        {
            DepartureDate = departureDate;
            IncomingDate = incomingDate;
            Flight = flight;
        }

        public void AddSeat(PlaneSeat seat)
        {
            _seats.Add(seat);
        }
    }
}