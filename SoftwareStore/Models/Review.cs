namespace SoftwareStore.Models
{
    public class Review
    {
        public int Id { get; set; } // ID 
        public string Name { get; set; } = ""; // Имя написавшего
        public string Information { get; set; } = ""; // Информация в сообщении к программе
        public Software Software { get; set; }
    }
}
