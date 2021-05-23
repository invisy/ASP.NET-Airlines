namespace Airlines.ApplicationCore.DTOs
{
    public class TravelClassDTO: BaseDto<int>
    {
        public string Name { get; set; }
        public float ClassPrice { get; set; }
    }
}