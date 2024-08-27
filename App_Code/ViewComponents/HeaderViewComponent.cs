

using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using UmbracoBlog.App_Code.Models.ViewComponentModels;
namespace UmbracoBlog.App_Code.ViewComponents
{

    public class HeaderViewComponent : ViewComponent
    {
        private readonly ILogger<HeaderViewComponent> logger;
        private readonly IUmbracoContextAccessor context;

        public HeaderViewComponent(ILogger<HeaderViewComponent> logger, IUmbracoContextAccessor context)
        {
            this.logger = logger;
            this.context = context;
        }


        public IViewComponentResult Invoke()
        {

            HeaderView headerView = new();
            try
            {
                var content = context.GetRequiredUmbracoContext()?.PublishedRequest?.PublishedContent;

                if (content is null)
                {
                    return View(headerView);
                }

                headerView.Title = content.Value<string>("title");
                headerView.SubTitle = content.Value<string>("subTitle");
                headerView.ImageUrl = content.Value<IPublishedContent>("pageBanner")?.Url();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in HeaderViewComponent");
            }

            return View(headerView);
        }



    }
}