using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airlines.Web.Models
{
    public class EnteringPrivateInfoViewModel
    {
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
    }
}