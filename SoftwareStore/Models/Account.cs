namespace SoftwareStore.Models
{
    public class Account
    {
        public int Id { get; set; } = 0; // ID
        public string Name { get; set; } = ""; // Имя
        public string Password { get; set; } = ""; // Пароль
        public bool Admin { get; set; } = false; // Есть или нет админка
        public List<Software> Softwares { get; set; } = new List<Software>(); // Список с ID купленных программ
    }
}
