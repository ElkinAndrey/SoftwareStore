namespace SoftwareStore.Models.ViewModel
{
    public class ProductViewModel
    {
        public string ReturnUrl { get; set; } // Url на который нужно перейти
        public Software Software { get; set; } // Приложение
        public Account? Account { get; set; } // Аккаунт
        public bool IsBought { get; set; } // Куплен ли продукт
        public string Information { get; set; } // Новый коментарий
    }
}
