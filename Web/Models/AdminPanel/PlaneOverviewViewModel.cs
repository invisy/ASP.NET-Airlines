using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airlines.Web.Models.AdminPanel
{
    public class PlaneOverviewViewModel
    {
        [Display(Name = "Ідентифікатор")]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Максимальна довжина - 50 знаків")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        
        [StringLength(10, ErrorMessage = "Максимальна довжина - 10 знаків")]
        [Display(Name = "Модель")]
        public string Model { get; set; }
        
        [Display(Name = "Кількість місць")]
        public int TotalSeats { get; set; }
        [Display(Name = "Класи польоту")]
        public List<string> TravelClassesNames { get; set; }
        
    }
}