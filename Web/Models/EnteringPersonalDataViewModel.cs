using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airlines.Web.Models
{
    public class EnteringPersonalDataViewModel
    {
        [Required]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Прізвище")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "По батькові")]
        public string Patronymic { get; set; }
        [Required]
        [Display(Name = "Номер паспорта")]
        public string UniquePassportId { get; set; }
        [Required]
        [Display(Name = "Вік")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Кінцева ціна")]
        public float Price { get; set; }
    }
}