namespace SoftwareStore.Models
{
    public class FakeApplicationRepository : IApplicationRepository
    {
        List<Account> Accounts { get; } = new List<Account>();

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
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
        public Account? CheckNameAccount(string name)
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

        public Account? CheckIdAccount(int id)
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
    }
}
