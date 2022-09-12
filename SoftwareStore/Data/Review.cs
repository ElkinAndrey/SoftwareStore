namespace SoftwareStore.Data
{
    // Коментарий
    public class Review
    {
        public int Id { get; set; } // ID 
        public string Information { get; set; } = ""; // Информация в сообщении к программе
        public Account Account { get; set; } // Аккаунт написавшего
        public Software Software { get; set; } // Программа, под которой оставили коментарий
    }
}
