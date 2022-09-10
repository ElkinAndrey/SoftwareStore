namespace SoftwareStore.Models.ViewModel
{
    // Вью модель для входа в аккаунт
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; } // Url на который нужно перейти после авторизации
        public string Name { get; set; } // имя пользователя
        public string Password { get; set; } // пароль пользователя
    }
}
