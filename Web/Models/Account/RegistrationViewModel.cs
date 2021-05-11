using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Airlines.Web.Models.Account
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Цей параметр є обов'язковим!")]
        [StringLength(30)]
        [DisplayName("Ім'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Цей параметр є обов'язковим!")]
        [StringLength(30)]
        [DisplayName("Прізвище")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Цей параметр є обов'язковим!")]
        [StringLength(30)]
        [DisplayName("По батькові")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Цей параметр є обов'язковим!")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Пошта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Цей параметр є обов'язковим!")]
        [StringLength(30)]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Цей параметр є обов'язковим!")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають!")]
        [StringLength(30)]
        [DataType(DataType.Password)]
        [DisplayName("Повторіть пароль")]
        public string RepeatPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}