using Umbraco.Core;
using System.Web.Mvc;
using System.Web.Routing;

namespace ThinkAnew.BundledBroker.UI
{
    public class RegisterEvents : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //Listen for when content is being saved
            BundleConfig.CreateBundles();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}