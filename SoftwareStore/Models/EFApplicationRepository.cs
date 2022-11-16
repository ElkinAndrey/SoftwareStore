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
            // Поиск элемента с именем
            var blog = context.Accounts.Where(b => b.Name == account.Name).FirstOrDefault();

            if (blog == null) // Чтобы не добавляло повторно
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }
        public Account? CheckNameAccount(string? name)
        {
            var blog = context.Accounts
                .Include(u => u.Softwares)
                .ThenInclude(u => u.Reviews)
                .Where(b => b.Name == name).FirstOrDefault();
            return blog;
        }

        public Account? CheckIdAccount(int? id)
        {
            var blog = context.Accounts.Find(id);
            return blog;
        }

        public void AddSoftware(Software? software)
        {
            // Поиск элемента с именем
            var blog = context.Softwares.Where(b => b.Name == software.Name).FirstOrDefault();

            if (blog == null) // Чтобы не добавляло повторно
            {
                context.Softwares.Add(software);
                context.SaveChanges();
            }
        }
        public Software? CheckNameSoftware(string? name)
        {
            var blog = context.Softwares
                .Include(u => u.Accounts)
                .Include(u => u.Reviews)
                .Where(b => b.Name == name).FirstOrDefault();
            return blog;
        }
        public Software? CheckIdSoftware(int? id)
        {
            var blog = context.Softwares.Find(id);
            return blog;
        }

        public void GiveSoftware(Account? account, Software? software)
        {
            if (account != null && software != null)
            {
                account.Softwares.Add(software);
                context.SaveChanges();
            }
        }

        public void AddReview(string? information, Account? account, Software? software)
        {
            
        }
    }
}
