using System.ComponentModel.DataAnnotations;

namespace SoftwareStore.Models.ViewModel
{
    // Вью модель для регистрации аккаунта
    public class RegistrationViewModel
    {
        public string ReturnUrl { get; set; } // Url на который нужно перейти после регистрации

        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; } // имя пользователя

        [Required(ErrorMessage = "Enter email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } // Email пользователя

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; } // Пароль пользователя
    }
}
