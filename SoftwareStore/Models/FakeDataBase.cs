namespace SoftwareStore.Models
{
    public static class FakeDataBase
    {
        public static List<Account> Accounts { get; } = new List<Account>(){
                new Account
                {
                    Name = "A",
                    Email = "A@A.A",
                    Password = "123",
                    Role = "Administrator"
                },
                new Account
                {
                    Name = "B",
                    Email = "B@B.B",
                    Password = "456"
                }
            };

        public static List<Software> Softwares { get; } = new List<Software>(){
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
}
