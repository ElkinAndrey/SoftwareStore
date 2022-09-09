namespace SoftwareStore.Data
{
    public class Account
    {
        public int Id { get; set; } = 0; // ID
        public string Name { get; set; } = ""; // Имя
        public string Email { get; set; } = ""; // Email
        public string Password { get; set; } = ""; // Пароль
        public string Role { get; set; } = ""; // Роль
    }
}
