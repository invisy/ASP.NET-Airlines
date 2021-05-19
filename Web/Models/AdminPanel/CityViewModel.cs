using System.ComponentModel.DataAnnotations;

namespace Airlines.Web.Models.AdminPanel
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Назва")]
        public string Name { get; set; }
    }
}