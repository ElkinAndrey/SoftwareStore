using System.ComponentModel.DataAnnotations;

namespace SoftwareStore.Models.ViewModel
{
    // Вью модель для входа в аккаунт
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; } // Url на который нужно перейти после авторизации

        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; } // имя пользователя

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; } // пароль пользователя
    }
}
