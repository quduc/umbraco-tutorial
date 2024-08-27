namespace UmbracoBlog.App_Code.Models.ViewComponentModels
{
    public class FooterView
    {
        public int? CurrentYear { get; set; }

        public List<FooterLink> FooterLinks { get; set; } = new();
    }


    public class FooterLink
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Target { get; set; }
    }
}