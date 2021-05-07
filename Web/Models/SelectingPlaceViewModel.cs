using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airlines.Web.Models
{
    public class SelectingPlaceViewModel
    {
        public List<SelectListItem> TravelClasses { get; set; }
        public List<SelectListItem> PlanePlaces { get; set; }
        [Display(Name = "Виберіть клас")]
        public int? SelectedTravelClassId { get; set; }
        [Display(Name = "Виберіть місце")]
        public int? SelectedPlanePlaceId { get; set; }
        [Display(Name = "Кінцева ціна")]
        public float Price { get; set; }
    }
}