using SoftwareStore.Data;

namespace SoftwareStore.Models
{
    public interface IApplicationRepository
    {
        public List<Account> Accounts { get; }
        public List<Software> Softwares { get; }
        public void AddAccount(Account? account);
        public Account? CheckNameAccount(string? name);
        public Account? CheckIdAccount(int? id);
        public void AddSoftware(Software? software);
        public Software? CheckNameSoftware(string? name);
        public Software? CheckIdSoftware(int? id);
    }
}
