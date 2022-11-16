using Microsoft.EntityFrameworkCore;

namespace SoftwareStore.Models
{
    public class EFApplicationRepository : IApplicationRepository
    {
        private ApplicationDbContext context;

        public EFApplicationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Account> Accounts => context.Accounts
            .Include(u => u.Softwares)
            .ThenInclude(u => u.Reviews)
            .ToList();

        public List<Software> Softwares => context.Softwares
            .Include(u => u.Accounts)
            .Include(u => u.Reviews)
            .ToList();

        public void AddAccount(Account? account)
        {

        }
        public Account? CheckNameAccount(string? name)
        {
            return null;
        }

        public Account? CheckIdAccount(int? id)
        {
            return null;
        }

        public void AddSoftware(Software? software)
        {

        }
        public Software? CheckNameSoftware(string? name)
        {
            return null;
        }
        public Software? CheckIdSoftware(int? id)
        {
            return null;
        }

        public void GiveSoftware(Account? account, Software? software)
        {

        }

        public void AddReview(string? information, Account? account, Software? software)
        {

        }
    }
}
