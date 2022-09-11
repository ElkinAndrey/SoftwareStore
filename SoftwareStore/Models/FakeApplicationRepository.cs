using SoftwareStore.Data;

namespace SoftwareStore.Models
{
    // Класс для работы с базой данных. Реализует интерфейс IApplicationRepository
    public class FakeApplicationRepository : IApplicationRepository
    {
        public List<Account> Accounts { get; } = FakeDataBase.Accounts;

        public List<Software> Softwares { get; } = FakeDataBase.Softwares;

        public void AddAccount(Account? account)
        {
            FakeDataBase.Accounts.Add(account);
        }
        public Account? CheckNameAccount(string? name)
        {
            foreach (var account in Accounts)
            {
                if (name == account.Name)
                {
                    return account;
                }
            }
            return null;
        }

        public Account? CheckIdAccount(int? id)
        {
            foreach (var account in Accounts)
            {
                if (id == account.Id)
                {
                    return account;
                }
            }
            return null;
        }

        public void AddSoftware(Software? software)
        {
            FakeDataBase.Softwares.Add(software);
        }
        public Software? CheckNameSoftware(string? name)
        {
            foreach (var software in Softwares)
            {
                if (name == software.Name)
                {
                    return software;
                }
            }
            return null;
        }
        public Software? CheckIdSoftware(int? id)
        {
            foreach (var software in Softwares)
            {
                if (id == software.Id)
                {
                    return software;
                }
            }
            return null;
        }
    }
}
