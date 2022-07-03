namespace SoftwareStore.Models
{
    public class Software
    {
        public int Id { get; set; } // ID 
        public string Name { get; set; } = ""; // Имя программы
        public string ShortInformation { get; set; } = ""; // Краткая информация о программе
        public string Information { get; set; } = ""; // Информация о программе
        public double Price { get; set; } // Цена программы
        public List<Review> Reviews { get; set; } = new List<Review>();// Список с ID отзывов
        public string File { get; set; } = ""; // Имя файла для скачивания
        public string Image { get; set; } = ""; // Имя картинки
        public List<Account> Accounts { get; set; } = new List<Account>();
        public double Size { get; set; } = 0;
        public string OS { get; set; } = "";
        public string Language { get; set; } = "";
        public DateTime Date { get; set; } = new DateTime();
        public int Downloads { get; set; } = 0;
    }
}
