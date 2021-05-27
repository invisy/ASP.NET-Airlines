using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airlines.Web.Models
{
    public class TicketUserInfoViewModel
    {
        public List<SelectListItem> TravelClasses { get; set; }
        public List<SelectListItem> PlanePlaces { get; set; }
        
        [Display(Name = "Виберіть клас")]
        public int? SelectedTravelClassId { get; set; }
        [Display(Name = "Виберіть місце")]
        public int? SelectedPlanePlaceId { get; set; }
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Display(Name = "Прізвище")]
        public string Surname { get; set; }
        [Display(Name = "По батькові")]
        public string Patronymic { get; set; }
        [Display(Name = "Номер паспорта")]
        public string UniquePassportId { get; set; }
        [Display(Name = "Вік")]
        public int Age { get; set; }
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }
        [Display(Name = "Кінцева ціна")]
        public float Price { get; set; }
    }
}