namespace SoftwareStore.Models.ViewModel
{
    public class GiveSoftwareViewModel
    {
        public string ReturnUrl { get; set; } // Url на который нужно перейти после авторизации
        public string Account { get; set; } // Имя
        public string Software { get; set; } // Название прораммы
    }
}
