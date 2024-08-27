using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using UmbracoBlog.App_Code.Models.ViewComponentModels;


namespace UmbracoBlog.App_Code.ViewComponents
{
    public class MetaDataViewComponent : ViewComponent
    {

        private readonly ILogger<MetaDataViewComponent> logger;
        private readonly IUmbracoContextAccessor context;
        public MetaDataViewComponent(ILogger<MetaDataViewComponent> logger, IUmbracoContextAccessor context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            MetaDataView metaDataView = new();
            try
            {
                var content = context.GetRequiredUmbracoContext()?.PublishedRequest?.PublishedContent;

                if (content is null)
                {
                    return View(metaDataView);
                }

                metaDataView.Title = content.Value<string>("title");
                metaDataView.Description = content.Value<string>("description");
                metaDataView.Author = content.Value<string>("author");

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in MetaDataViewComponent");
            }

            return View(metaDataView);
        }

    }
}