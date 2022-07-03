using System.ComponentModel.DataAnnotations;

namespace SoftwareStore.Models.ViewModels
{
    // Класс для хранения данных новой программы, которую добавляет администратор
    public class ProductViewModel
    {
        public string NameAdmin { get; set; } = "";
        public string NameBuyer { get; set; } = "";
        public string Product { get; set; } = "";
        public Software Software { get; set; } = new Software();
        public IFormFile? GetFile { get; set; } = null;
        public IFormFile? GetImage { get; set; } = null;
    }
}
