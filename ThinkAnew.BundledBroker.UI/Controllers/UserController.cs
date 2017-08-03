using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace ThinkAnew.BundledBroker.UI.Controllers
{
    [Extensions.AjaxAuthorize]
    public class UserController : BaseSurfaceController
    {
        private readonly DAL.BundledBrokerEntities _db = new DAL.BundledBrokerEntities();

        //
        //GET: /Account/ManageList
        [HttpGet]
        [Authorize]
        [Extensions.AjaxAuthorize]
        public ActionResult Index()
        {
            return PartialView(@"~/Views/Partials/App/User.cshtml");
        }

        [Extensions.AjaxAuthorize]
        public ActionResult Users_Read([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<DAL.UserLogin> users = _db.UserLogins;

            DataSourceResult result = users.Select(user => new Models.UserViewModel
            {
                UserId = user.UserId,
                UserName1 = user.UserName,
                UserName2 = user.UserName,
                Password1 = user.Password,
                Password2 = user.Password,
                LastLoginDate = user.LastLoginDate,
                ResetIdentifier = user.ResetIdentifier,
                CreationDate = user.CreationDate,
                UserIsActive = user.UserIsActive,
                FirstName = user.User.FirstName,
                LastName = user.User.LastName,
                Phone = user.User.Phone,
                UserRoles = _db.UserRoles.Where(ur => ur.UserId == user.UserId).Select(ur => new Models.RoleViewModel { RoleId = ur.RoleId, RoleName = ur.Role.RoleName}),
                UserGroups = _db.UserGroups.Where(ug => ug.UserId  == user.UserId).Select(ug => ug.GroupId)
            }).ToDataSourceResult(request);

            return Json(result);
        }

        [Extensions.AjaxAuthorize]
        public ActionResult GetRoles()
        {
            return Json(_db.Roles.Where(r => r.RoleIsAssignable).Select(r => new
            {
                r.RoleId,
                r.RoleName
            }), JsonRequestBehavior.AllowGet);
        }

        [Extensions.AjaxAuthorize]
        public ActionResult GetRolesByUserId(int userId)
        {
            var userRoles = _db.Roles.GroupJoin(
                    _db.UserRoles,
                    foo => foo.RoleId,
                    bar => bar.RoleId,
                    (x, y) => new { Foo = x, Bars = y })
                .SelectMany(
                    x => x.Bars.DefaultIfEmpty(),
                    (x, y) => new Models.UserRoleViewModel()
                    {
                        UserId = y.UserId,
                        RoleName = x.Foo.RoleName,
                        RoleId = x.Foo.RoleId,
                        UserRoleId = y.UserRoleId
                    });

            return Json(userRoles, JsonRequestBehavior.AllowGet);
        }

        [Extensions.AjaxAuthorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Create([DataSourceRequest]DataSourceRequest request, Models.FacilityViewModel facility)
        {
            throw new NotImplementedException();
        }

        [Extensions.AjaxAuthorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, Models.FacilityViewModel facility)
        {
            throw new NotImplementedException();
        }

        [Extensions.AjaxAuthorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest] DataSourceRequest request, Models.FacilityViewModel facility)
        {
            throw new NotImplementedException();
        }

    }
}