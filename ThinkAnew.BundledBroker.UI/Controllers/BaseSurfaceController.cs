using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThinkAnew.BundledBroker.UI.Helpers;
using Umbraco.Web.Mvc;

namespace ThinkAnew.BundledBroker.UI.Controllers
{
    public abstract class BaseSurfaceController : SurfaceController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dismissable"></param>
        public void AlertSuccess(string message, bool dismissable = false)
        {
            AddAlert(Helpers.AlertStyles.Success, message, dismissable);
        }

        public void AlertInformation(string message, bool dismissable = false)
        {
            AddAlert(Helpers.AlertStyles.Information, message, dismissable);
        }

        public void AlertWarning(string message, bool dismissable = false)
        {
            AddAlert(Helpers.AlertStyles.Warning, message, dismissable);
        }

        public void AlertError(string message, bool dismissable = false)
        {
            AddAlert(Helpers.AlertStyles.Danger, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            List<Alert> alerts = TempData.ContainsKey(Helpers.Alert.TempDataKey)
                ? (System.Collections.Generic.List<Helpers.Alert>) TempData[Helpers.Alert.TempDataKey]
                : new System.Collections.Generic.List<Helpers.Alert>();

            alerts.Add(new Helpers.Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[Helpers.Alert.TempDataKey] = alerts;
        }
    }
}