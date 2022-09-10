namespace SoftwareStore.Models.ViewModel
{
    // Вью модель для регистрации аккаунта
    public class RegistrationViewModel
    {
        public string ReturnUrl { get; set; } // Url на который нужно перейти после регистрации
        public string Name { get; set; } // имя пользователя
        public string Email { get; set; } // Email пользователя
        public string Password { get; set; } // Пароль пользователя
    }
}
