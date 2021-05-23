using System.Collections.Generic;

namespace Airlines.ApplicationCore.DTOs
{
    public class PlaneOverviewDTO : BaseDto<int>
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int TotalSeats { get; set; }
        public IEnumerable<string> TravelClassesNames { get; set; }
    }
}