namespace Airlines.ApplicationCore.DTOs
{
    public class PlaneFlatDTO : BaseDto<int>
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int TotalSeats { get; set; }
    }
}