using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Airlines.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Пошта")]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DisplayName("Запам'ятати?")]
        public bool Remember { get; set; }
        public string ReturnUrl { get; set; }
    }
}