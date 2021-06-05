namespace Airlines.ApplicationCore.Entities
{
    public class Ticket : BaseEntity<int>
    {
        public Passenger Passenger { get; private set; }
        public float TotalPrice { get; set; }
        
        //EF
        public Ticket() { }
        
        public Ticket(Passenger passenger)
        {
            Passenger = passenger;
        }
    }
}