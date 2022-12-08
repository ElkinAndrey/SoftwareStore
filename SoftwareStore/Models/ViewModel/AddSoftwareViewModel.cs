using System.ComponentModel.DataAnnotations;

namespace SoftwareStore.Models.ViewModel
{
    public class AddSoftwareViewModel
    {
        public string ReturnUrl { get; set; } // Url на который нужно перейти после авторизации
        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; } = ""; // Имя программы
        [Required(ErrorMessage = "Enter short information")]
        [MaxLength(50)]
        public string ShortInformation { get; set; } = ""; // Краткая информация о программе
        [Required(ErrorMessage = "Enter information")]
        public string Information { get; set; } = ""; // Информация о программе
        [Required(ErrorMessage = "Enter price")]
        public decimal? Price { get; set; } // Цена программы

    }
}
