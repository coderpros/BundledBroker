using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ThinkAnew.BundledBroker.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Session_Start(object sender, EventArgs e)
        {
            Response.Redirect(@"~/signed-out/", true);
        }
    }
}
