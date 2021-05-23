using System.ComponentModel.DataAnnotations;

namespace Airlines.Web.Models.AdminPanel
{
    public class PlaneFlatViewModel
    {
        [Display(Name = "Ідентифікатор")]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Максимальна довжина - 50 знаків")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Максимальна довжина - 10 знаків")]
        [Display(Name = "Модель")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Кількість місць")]
        [Range(0, 100000)]
        public int TotalSeats { get; set; }
    }
}