﻿using System;
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
    [Extensions.AjaxAuthorize]
    public class GroupController : BaseSurfaceController
    {
        private readonly BundledBrokerEntities _db = new BundledBrokerEntities();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return PartialView(@"~/Views/Partials/App/Group.cshtml");
        }

        [Authorize]
        public ActionResult Groups_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Group> groups = _db.Groups;
            DataSourceResult result = groups.ToDataSourceResult(request, c => new GroupViewModel 
            {
                GroupId = c.GroupId,
                GroupName = c.GroupName,
                MaxAllowedUsers = c.MaxAllowedUsers,
                MaxAllowedFacilities = c.MaxAllowedFacilities,
                AgreedToBaa = c.Agreed_To_Baa,
                Active = c.GroupIsActive
            });

            return Json(result);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Groups_Create([DataSourceRequest]DataSourceRequest request, int GroupId, string GroupName, int MaxAllowedUsers, int MaxAllowedFacilities, bool AgreedToBaa, bool Active)
        {
            var groupViewModel = new GroupViewModel()
            {
                GroupId = GroupId,
                GroupName = GroupName,
                MaxAllowedUsers = MaxAllowedUsers,
                MaxAllowedFacilities = MaxAllowedFacilities,
                AgreedToBaa = AgreedToBaa,
                Active = Active
            };

            if (ModelState.IsValid)
            {
                var entity = new Group
                {
                    GroupName = GroupName,
                    MaxAllowedUsers = MaxAllowedUsers,
                    MaxAllowedFacilities = MaxAllowedFacilities,
                    Agreed_To_Baa = AgreedToBaa,
                    GroupIsActive = Active
                };

                _db.Groups.Add(entity);
                _db.SaveChanges();

                groupViewModel.GroupId = entity.GroupId;
            }

            return Json(new[] { groupViewModel }.ToDataSourceResult(request, ModelState));
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Groups_Update([DataSourceRequest]DataSourceRequest request, int GroupId, string GroupName, int MaxAllowedUsers, int MaxAllowedFacilities, bool AgreedToBaa, bool Active)
        {
            var groupViewModel = new GroupViewModel()
            {
                GroupId = GroupId,
                GroupName = GroupName,
                MaxAllowedUsers = MaxAllowedUsers,
                MaxAllowedFacilities = MaxAllowedFacilities,
                AgreedToBaa = AgreedToBaa,
                Active = Active
            };

            if (ModelState.IsValid)
            {
                var entity = new Group
                {
                    GroupId = GroupId,
                    GroupName = GroupName,
                    MaxAllowedUsers = MaxAllowedUsers,
                    MaxAllowedFacilities = MaxAllowedFacilities,
                    Agreed_To_Baa = AgreedToBaa,
                    GroupIsActive = Active
                };

                _db.Groups.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return Json(new[] { groupViewModel }.ToDataSourceResult(request, ModelState));
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Groups_Destroy([DataSourceRequest]DataSourceRequest request, int GroupId, string GroupName, int MaxAllowedUsers, int MaxAllowedFacilities, bool AgreedToBaa, bool Active)
        {
            var groupViewModel = new GroupViewModel()
            {
                GroupId = GroupId,
                GroupName = GroupName,
                MaxAllowedUsers = MaxAllowedUsers,
                MaxAllowedFacilities = MaxAllowedFacilities,
                AgreedToBaa = AgreedToBaa,
                Active = Active
            };

            if (ModelState.IsValid)
            {
                var entity = new Group
                {
                    GroupId = GroupId,
                    GroupName = GroupName,
                    MaxAllowedUsers = MaxAllowedUsers,
                    MaxAllowedFacilities = MaxAllowedFacilities,
                    Agreed_To_Baa = AgreedToBaa,
                    GroupIsActive = Active
                };

                _db.Groups.Attach(entity);
                _db.Groups.Remove(entity);
                _db.SaveChanges();
            }

            return Json(new[] { groupViewModel }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult GetGroups()
        {
            return Json(_db.Groups.Where(r => r.GroupIsActive).Select(g => new
            {
                GroupName = g.GroupName,
                GroupId = g.GroupId

            }), JsonRequestBehavior.AllowGet);
            
        }
    }
}
