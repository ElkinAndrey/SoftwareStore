namespace SoftwareStore.Data
{
    // Программа, которую будут покупать пользователи
    public class Software
    {
        public int Id { get; set; } // ID 
        public string Name { get; set; } = ""; // Имя программы
        public string ShortInformation { get; set; } = ""; // Краткая информация о программе
        public string Information { get; set; } = ""; // Информация о программе
        public decimal Price { get; set; } // Цена программы
    }
}
