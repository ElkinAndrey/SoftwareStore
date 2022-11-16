using SoftwareStore.Data;

namespace SoftwareStore.Models
{
    // Интерфейс для работы с базой данных
    public interface IApplicationRepository
    {
        public List<Account> Accounts { get; } // Список всех аккаунтов
        public List<Software> Softwares { get; } // Список всех приложений
        public void AddAccount(Account? account); // Добавить аккаунт
        public Account? CheckNameAccount(string? name); // Найти аккаунт по имени
        public Account? CheckIdAccount(int? id); // Найти аккаунт по id
        public void AddSoftware(Software? software); // Добавить приложение
        public Software? CheckNameSoftware(string? name); // Найти приложение по имени
        public Software? CheckIdSoftware(int? id); // Найти приложение по id
        public void GiveSoftware(Account? account, Software? software);
        public void AddReview(string? information, Account? account, Software? software);
        public void GiveAdmin(Account? account);
    }
}
