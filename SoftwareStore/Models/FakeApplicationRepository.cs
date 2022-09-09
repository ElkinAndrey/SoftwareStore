using SoftwareStore.Data;

namespace SoftwareStore.Models
{
    public class FakeApplicationRepository : IApplicationRepository
    {
        public List<Account> Accounts { get; }

        public List<Software> Softwares { get; }

        public FakeApplicationRepository()
        {
            this.Accounts = new List<Account>
            {
                new Account
                {
                    Name = "A",
                    Email = "A@A.A",
                    Password = "123"
                },
                new Account
                {
                    Name = "B",
                    Email = "B@B.B",
                    Password = "456"
                }
            };

            this.Softwares = new List<Software>
            {
                new Software
                {
                    Name = "Software1",
                    ShortInformation = "Short Information about Software1",
                    Information = "Information about Software1",
                    Price = 1
                },
                new Software
                {
                    Name = "Software2",
                    ShortInformation = "Short Information about Software2",
                    Information = "Information about Software2",
                    Price = 2
                },
            };
        }

        public void AddAccount(Account? account)
        {
            Accounts.Add(account);
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
            Softwares.Add(software);
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
