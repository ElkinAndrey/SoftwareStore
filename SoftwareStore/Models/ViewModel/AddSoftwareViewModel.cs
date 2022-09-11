namespace SoftwareStore.Models.ViewModel
{
    public class AddSoftwareViewModel
    {
        public string ReturnUrl { get; set; } // Url на который нужно перейти после авторизации
        public Software Software { get; set; } // Новое приложение
    }
}
