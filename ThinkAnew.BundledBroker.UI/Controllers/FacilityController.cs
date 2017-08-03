using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using ThinkAnew.BundledBroker.DAL;

namespace ThinkAnew.BundledBroker.UI.Controllers
{
    [Extensions.AjaxAuthorize]
    public class FacilityController : BaseSurfaceController
    {
        private readonly BundledBrokerEntities _db = new BundledBrokerEntities();

        [Authorize]
        public ActionResult Index()
        {
            ViewData.Add(@"States", new SelectList(_db.States, @"StateId", @"StateName"));
            ViewData.Add(@"Counties", new SelectList(_db.USCounties.Select(c => new { c.USCountiesId, c.CountyName }), @"USCountiesId", @"CountyName"));
            ViewData.Add(@"Groups", new SelectList(_db.Groups, @"GroupId", @"GroupName"));

            return PartialView(@"~/Views/Partials/App/Facility.cshtml");
        }

        public ActionResult FacilityByGroupId(int groupId)
        {
            ViewData.Add(@"States", new SelectList(_db.States, @"StateId", @"StateName"));
            ViewData.Add(@"Counties", new SelectList(_db.USCounties.Select(c => new { c.USCountiesId, c.CountyName }), @"USCountiesId", @"CountyName"));
            ViewData.Add(@"Groups", new SelectList(_db.Groups, @"GroupId", @"GroupName"));

            ViewBag.GroupId = groupId;

            return PartialView(@"~/Views/Partials/App/Facility.cshtml");
        }

        public ActionResult Facilities_Read([DataSourceRequest]DataSourceRequest request)
        {
            //int groupId = 0;
            //if (ViewBag.GroupId != null) groupId = int.Parse(ViewBag.GroupId);

            //_db.Configuration.ProxyCreationEnabled = false;
            IQueryable<Facility> facilities = _db.Facilities;
            //if (groupId > 0) facilities = facilities.Where(f => f.GroupId == groupId);

            DataSourceResult result = facilities.Select(facility => new Models.FacilityViewModel 
            {
                FacilityId = facility.FacilityId,
                GroupId = facility.GroupId,
                StateId = facility.StateId,
                CountyId = facility.CountyId,
                FacilityCode = facility.FacilityCode,
                FacilityName = facility.FacilityName,
                City = facility.City,
                Postal = facility.Postal,
                FacilityIsActive = facility.FacilityIsActive,
                GroupName = facility.Group.GroupName,
                LastPullDate = facility.FacilityPullDatas.Any() ? facility.FacilityPullDatas.OrderBy(p => p.LastDateOfPull).FirstOrDefault().LastDateOfPull : null,
                LastClaimDate = facility.Claims.Any() ? facility.Claims.OrderBy(c => c.EndDate).FirstOrDefault().EndDate : null
            }).ToDataSourceResult(request);
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Facilities_Create([DataSourceRequest]DataSourceRequest request, Models.FacilityViewModel facility)
        {
            if (ModelState.IsValid)
            {
                var entity = new Facility
                {
                    GroupId = facility.GroupId,
                    StateId = facility.StateId,
                    CountyId = facility.CountyId,
                    FacilityCode = facility.FacilityCode,
                    FacilityName = facility.FacilityName,
                    City = facility.City,
                    Postal = facility.Postal,
                    FacilityIsActive = facility.FacilityIsActive,
                };

                _db.Facilities.Add(entity);
                _db.SaveChanges();
                facility.FacilityId = entity.FacilityId;
            }

            return Json(new[] { facility }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Facilities_Update([DataSourceRequest]DataSourceRequest request, Models.FacilityViewModel facility)
        {
            if (ModelState.IsValid)
            {
                var entity = new Facility
                {
                    FacilityId = facility.FacilityId,
                    GroupId = facility.GroupId,
                    StateId = facility.StateId,
                    CountyId = facility.CountyId,
                    FacilityCode = facility.FacilityCode,
                    FacilityName = facility.FacilityName,
                    City = facility.City,
                    Postal = facility.Postal,
                    FacilityIsActive = facility.FacilityIsActive,
                };

                _db.Facilities.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return Json(new[] { facility }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Facilities_Destroy([DataSourceRequest]DataSourceRequest request, Models.FacilityViewModel facility)
        {
            if (ModelState.IsValid)
            {
                var entity = new Facility
                {
                    FacilityId = facility.FacilityId,
                    GroupId = facility.GroupId,
                    StateId = facility.StateId,
                    FacilityCode = facility.FacilityCode,
                    FacilityName = facility.FacilityName,
                    City = facility.City,
                    Postal = facility.Postal,
                    CountyId = facility.CountyId,
                    FacilityIsActive = facility.FacilityIsActive,
                };

                _db.Facilities.Attach(entity);
                _db.Facilities.Remove(entity);
                _db.SaveChanges();
            }

            return Json(new[] { facility }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
