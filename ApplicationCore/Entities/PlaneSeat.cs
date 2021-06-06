using System;

namespace Airlines.ApplicationCore.Entities
{
    public class PlaneSeat : BaseEntity<int>
    {
        public string Number { get; private set; }
        public TravelClass TravelClass { get; private set; }
        public int TravelClassId { get; private set; }
        public Ticket Ticket { get; set; }
        public int? TicketId { get; private set; }
        public virtual int FlightInstanceId { get; private set; }
        
        public PlaneSeat() {}
        public PlaneSeat(string number, int travelClassId)
        {
            Number = number;
            TravelClassId = travelClassId;
        }
        
        public void UpdateNumber(string number)
        {
            if (number.Length is 0 or > 10)
                throw new ArgumentOutOfRangeException(nameof(number));
            Number = number;
        }
    }
}