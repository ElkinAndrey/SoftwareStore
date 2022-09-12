namespace SoftwareStore.Data
{
    // Аккаунт пользователя
    public class Account
    {
        public int Id { get; set; } = 0; // ID
        public string Name { get; set; } = ""; // Имя
        public string Email { get; set; } = ""; // Email
        public string Password { get; set; } = ""; // Пароль
        public string Role { get; set; } = ""; // Роль
        public List<Software> Softwares { get; set; } = new List<Software>(); // Список купленных программ
        public List<Review> Reviews { get; set; } = new List<Review>(); // Список оставленных коментариев

    }
}
