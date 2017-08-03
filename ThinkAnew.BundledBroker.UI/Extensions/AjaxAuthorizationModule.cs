using System;
using System.Web;
using System.Web.Mvc;

namespace ThinkAnew.BundledBroker.UI.Extensions
{
    public class AjaxAuthorizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += CheckForAuthFailure;
        }

        private void CheckForAuthFailure(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            var response = new HttpResponseWrapper(app.Response);
            var request = new HttpRequestWrapper(app.Request);
            var context = new HttpContextWrapper(app.Context);

            CheckForAuthFailure(request, response, context);
        }

        internal void CheckForAuthFailure(HttpRequestBase request, HttpResponseBase response, HttpContextBase context)
        {
            if (true.Equals(context.Items["RequestWasNotAuthorized"]) && request.IsAjaxRequest())
            {
                response.StatusCode = 401;
                response.ClearContent();
            }
        }

        public void Dispose()
        {
        }
    }
}