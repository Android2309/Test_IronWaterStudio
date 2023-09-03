using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [DisplayName("Логин")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        public string? Password { get; set; }
    }
}
