using System.ComponentModel.DataAnnotations;

namespace Airlines.Web.Models.AdminPanel
{
    public class CityViewModel
    {
        [Display(Name = "Ідентифікатор")]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Максимальна довжина - 50 знаків")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
    }
}