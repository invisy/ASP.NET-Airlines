using System.Collections.Generic;
using Airlines.ApplicationCore.Entities;

namespace Airlines.ApplicationCore.DTOs
{
    public class PlaneDTO : BaseDto<int>
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int TotalSeats { get; set; }
        public IEnumerable<TravelClassDTO> TravelClasses { get; set; }
    }
}