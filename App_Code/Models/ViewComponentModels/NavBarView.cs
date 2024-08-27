namespace UmbracoBlog.App_Code.Models.ViewComponentModels
{
    public class NavBarView
    {
        public String? SiteName { get; set; }
        public List<NavBarChild> NavBarChildren { get; set; } = new List<NavBarChild>();
    }

    public class NavBarChild
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
    }
}