namespace SoftwareStore.Models
{
    public class EFApplicationRepository : IApplicationRepository
    {
        private ApplicationDbContext context;

        public List<Account> Accounts { get; } = FakeDataBase.Accounts;

        public List<Software> Softwares { get; } = FakeDataBase.Softwares;

        public List<Review> Reviews { get; } = FakeDataBase.Reviews;

        public EFApplicationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

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
