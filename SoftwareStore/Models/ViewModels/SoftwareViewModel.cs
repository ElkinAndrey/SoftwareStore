namespace SoftwareStore.Models.ViewModels
{
    public class AllMySoftware
    {
        public Software Software { get; set; }
        public bool My { get; set; } = false;
    }
    public class SoftwareViewModel
    {
        public List<AllMySoftware> Softwares { get; set; } = new List<AllMySoftware>();
        public string SearchString { get; set; } = "";
    }
}
