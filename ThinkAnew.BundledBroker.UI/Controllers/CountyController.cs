using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ThinkAnew.BundledBroker.DAL;

namespace ThinkAnew.BundledBroker.UI.Controllers
{
    public class CountyController : BaseSurfaceController
    {
        private readonly BundledBrokerEntities _db = new BundledBrokerEntities();

        // GET: County/GetById
        [HttpGet]
        public ActionResult GetByStateId(int id)
        {
            //var selectList = new SelectList(_db.USCounties.Where(c => c.StateId == id).Select(c => new { Value = c.USCountiesId, Text = c.CountyName }), @"USCountiesId", @"CountyName");

            //ViewData["Counties"] = selectList;

            return Json(_db.USCounties.Where(c => c.StateId == id).Select(c => new { Value = c.USCountiesId, Text = c.CountyName }), JsonRequestBehavior.AllowGet);
        }
    }
}