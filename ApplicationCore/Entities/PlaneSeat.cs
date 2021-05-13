namespace Airlines.ApplicationCore.Entities
{
    public class PlaneSeat : BaseEntity<int>
    {
        public string Number { get; private set; }
        public TravelClass TravelClass { get; private set; }
        public Ticket Ticket { get; set; }

        public PlaneSeat()
        {
        }
        
        public PlaneSeat(string number, TravelClass travelClass)
        {
            Number = number;
            TravelClass = travelClass;
        }
    }
}