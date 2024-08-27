using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoBlog.App_Code.Models.ViewComponentModels;

namespace UmbracoBlog.App_Code.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {

        private readonly ILogger<FooterViewComponent> logger;
        private readonly UmbracoHelper umbracoHelper;

        public IViewComponentResult Invoke()
        {

            FooterView footerView = new();
            try
            {
                var currentYear = DateTime.Now.Year;

                footerView.CurrentYear = currentYear;

                var homePage = umbracoHelper?.ContentAtRoot().FirstOrDefault(x => x.IsDocumentType("home") && x.IsVisible()) as Home;

                if (homePage is null)
                {
                    return View(footerView);
                }
                foreach (var item in homePage?.FooterLinks)
                {
                    footerView?.FooterLinks?.Add(new FooterLink
                    {
                        Name = item.Name,
                        Url = item.Url,
                        Target = item.Target
                    });

                }



            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in FooterViewComponent");
            }

            return View(footerView);
        }
    }
}