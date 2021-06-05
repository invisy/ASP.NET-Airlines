using System.ComponentModel.DataAnnotations;

namespace Airlines.Web.Models
{
    public class EnteringTicketDataViewModel
    {
        public SelectingPlaceViewModel SelectingPlace { get; set; }
        [Required]
        public EnteringPersonalDataViewModel EnteringPersonalData { get; set; }
    }
}