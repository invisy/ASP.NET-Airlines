namespace Airlines.ApplicationCore.Entities
{
    public class Ticket : BaseEntity<int>
    {
        public Passenger Passenger { get; private set; }
        public Flight Flight { get; private set; }
        public float TotalPrice { get; private set; }

        
        public Ticket(Passenger passenger, Flight flight)
        {
            Passenger = passenger;
            Flight = flight;
        }
        
        private float CalculateTotalPrice()
        {
            throw new System.NotImplementedException();
        }
    }
}