using System.ComponentModel.DataAnnotations;

namespace Airlines.Web.Models.AdminPanel
{
    public class TravelClassViewModel
    {
        [Display(Name = "Ідентифікатор")]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Максимальна довжина - 50 знаків")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required]
        [Range(typeof(float), "0,0", "100000,0", ErrorMessage = "Значення має бути більше 0 та менше 100000")]
        [Display(Name = "Додаткова ціна за клас")]
        public float ClassPrice { get; set; }
    }
}