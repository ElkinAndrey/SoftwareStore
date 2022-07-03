namespace SoftwareStore.Models
{
    public interface IApplicationRepository
    {
        List<Account> Accounts { get; }
        List<Software> Softwares { get; }
        public void AddAccount(Account account);
        public void AddSoftware(Software software);
        public Account? CheckNameAccount(Account account);
        public Software? CheckNameSoftware(Software software);
        public Account? CheckIdAccount(int id);
        public Software? CheckIdSoftware(int id);
        public void Update();
    }
}
