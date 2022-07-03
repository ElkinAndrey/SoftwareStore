namespace SoftwareStore.Models
{
    public static class SignInAccount
    {
        public static Account? Account { get; set; } = null;

        public static void SignIn(Account account)
        {
            Account = account;
        }
        public static void SignOut()
        {
            Account = null;
        }
    }
}
