using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ThinkAnew.BundledBroker.DAL;
using ThinkAnew.BundledBroker.UI.Models;

namespace ThinkAnew.BundledBroker.UI.Controllers
{
    public class StateController : BaseSurfaceController
    {
        private readonly BundledBrokerEntities _db = new BundledBrokerEntities();

        public ActionResult States_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<State> states = _db.States;
            DataSourceResult result = states.ToDataSourceResult(request, c => new DAL.State
            {
                StateId = c.StateId,
                StateCode = c.StateCode,
                StateName = c.StateName
            });

            return Json(result);
        }
    }
}