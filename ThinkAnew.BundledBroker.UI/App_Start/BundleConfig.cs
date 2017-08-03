using System.Web;
using ClientDependency.Core;

namespace ThinkAnew.BundledBroker.UI
{
    public class BundleConfig
    {
        public static void CreateBundles()
        {
            #region Javascript Bundles
            BundleManager.CreateJsBundle(@"jQuery",
                new JavascriptFile(@"~/Scripts/jquery-3.1.1.js"),
                new JavascriptFile(@"~/Scripts/jquery-migrate-3.0.0.js"),
                new JavascriptFile(@"~/Scripts/jquery.easing.1.3.js"));

            BundleManager.CreateJsBundle(@"jQueryValidation",
                new JavascriptFile(@"~/Scripts/jquery.validate.js"),
                new JavascriptFile(@"https://ajax.aspnetcdn.com/ajax/mvc/5.1/jquery.validate.unobtrusive.min.js"),
                new JavascriptFile(@"~/Scripts/jquery.unobtrusive-ajax.js"));

            BundleManager.CreateJsBundle(@"bootstrap",
                new JavascriptFile(@"~/Scripts/bootstrap.js"));

            BundleManager.CreateJsBundle(@"globalScripts",
                new JavascriptFile(@"~/Scripts/scrolling-nav.js"),
                new JavascriptFile(@"~/Scripts/respond.js"));

            BundleManager.CreateJsBundle(@"kendo",
                new JavascriptFile(@"https://kendo.cdn.telerik.com/2017.2.504/js/jszip.min.js"),
                new JavascriptFile(@"https://kendo.cdn.telerik.com/2017.2.504/js/kendo.all.min.js"),
                new JavascriptFile(@"https://kendo.cdn.telerik.com/2017.2.504/js/kendo.aspnetmvc.min.js"),
                new JavascriptFile(@"~/Scripts/kendo.modernizr.custom.js"));
            #endregion

            #region Css Bundles

            BundleManager.CreateCssBundle(@"bootstrap",
                new CssFile(@"~/Content/bootstrap.css"),
                new CssFile(@"~/Content/bootstrap-theme.css"));

            BundleManager.CreateCssBundle(@"site",
                new CssFile(@"~/css/Site.css"),
                new CssFile(@"~/Content/font-awesome.css"));

            BundleManager.CreateCssBundle(@"kendo",
                new CssFile("https://kendo.cdn.telerik.com/2017.2.504/styles/kendo.common.min.css"),
                new CssFile("https://kendo.cdn.telerik.com/2017.2.504/styles/kendo.mobile.all.min.css"),
                new CssFile("https://kendo.cdn.telerik.com/2017.2.504/styles/kendo.dataviz.min.css"),
                new CssFile("https://kendo.cdn.telerik.com/2017.2.504/styles/kendo.metro.min.css"),
                new CssFile("https://kendo.cdn.telerik.com/2017.2.504/styles/kendo.dataviz.metro.min.css"));

            #endregion
        }
    }
}
