using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoBlog.App_Code.Models.ViewComponentModels;


namespace UmbracoBlog.App_Code.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {

        private readonly ILogger<NavBarViewComponent> logger;
        private readonly UmbracoHelper umbracoHelper;

        public NavBarViewComponent(ILogger<NavBarViewComponent> logger, UmbracoHelper umbracoHelper)
        {
            this.logger = logger;
            this.umbracoHelper = umbracoHelper;
        }
        public IViewComponentResult Invoke()
        {
            NavBarView navBarView = new();
            try
            {

                var homePage = umbracoHelper?.ContentAtRoot().FirstOrDefault(x => x.IsDocumentType("home") && x.IsVisible()) as Home;

                if (homePage is null)
                {
                    return View(navBarView);
                }

                navBarView.SiteName = homePage?.SiteName;

                foreach (var item in homePage?.Children)
                {
                    if (item?.Value<bool>("displayOnNavBar") == true)
                    {
                        navBarView.NavBarChildren.Add(new NavBarChild
                        {
                            Name = item.Name,
                            Url = item.Url()
                        });
                    }

                }

                return View(navBarView);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in NavBarViewComponent");
            }

            return View(navBarView);
        }
    }
}