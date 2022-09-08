namespace SoftwareStore.Models
{
    public interface IApplicationRepository
    {
        public void AddAccount(Account account);
        public Account? CheckNameAccount(string account);
        public Account? CheckIdAccount(int id);
    }
}
