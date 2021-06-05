using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airlines.Web.Models
{
    public class SelectingPlaceViewModel
    {
        public SelectList TravelClasses { get; set; }
        public SelectList PlanePlaces { get; set; }
        [Required]
        [Display(Name = "Виберіть клас")]
        public int SelectedTravelClassId { get; set; }
        [Required]
        [Display(Name = "Виберіть місце")]
        public int SelectedPlanePlaceId { get; set; }
    }
}