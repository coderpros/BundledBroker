﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThinkAnew.BundledBroker.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BundledBrokerEntities : DbContext
    {
        public BundledBrokerEntities()
            : base("name=BundledBrokerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AHTFacilityConnection> AHTFacilityConnections { get; set; }
        public virtual DbSet<AttendingPhysician> AttendingPhysicians { get; set; }
        public virtual DbSet<ClaimDetail> ClaimDetails { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<ClaimType> ClaimTypes { get; set; }
        public virtual DbSet<ConnectionType> ConnectionTypes { get; set; }
        public virtual DbSet<DRGCode> DRGCodes { get; set; }
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<FacilityConnection> FacilityConnections { get; set; }
        public virtual DbSet<FacilityLookup> FacilityLookups { get; set; }
        public virtual DbSet<FacilityPullData> FacilityPullDatas { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<LoginHistory> LoginHistories { get; set; }
        public virtual DbSet<ModelType> ModelTypes { get; set; }
        public virtual DbSet<OrderedResult> OrderedResults { get; set; }
        public virtual DbSet<ReferringHospital> ReferringHospitals { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<RevenueCodeMultiplier> RevenueCodeMultipliers { get; set; }
        public virtual DbSet<RevenueCode> RevenueCodes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoutineCostOfCare> RoutineCostOfCares { get; set; }
        public virtual DbSet<RowType> RowTypes { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<USCounty> USCounties { get; set; }
        public virtual DbSet<UserFacility> UserFacilities { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        [DbFunction("BundledBrokerEntities", "SplitString")]
        public virtual IQueryable<SplitString_Result> SplitString(string input, string character)
        {
            var inputParameter = input != null ?
                new ObjectParameter("Input", input) :
                new ObjectParameter("Input", typeof(string));
    
            var characterParameter = character != null ?
                new ObjectParameter("Character", character) :
                new ObjectParameter("Character", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<SplitString_Result>("[BundledBrokerEntities].[SplitString](@Input, @Character)", inputParameter, characterParameter);
        }
    
        public virtual int GenerateBundleReport(Nullable<int> facilityId, Nullable<int> userID, Nullable<int> reportType, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> endDate, Nullable<int> dRG)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var reportTypeParameter = reportType.HasValue ?
                new ObjectParameter("ReportType", reportType) :
                new ObjectParameter("ReportType", typeof(int));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var dRGParameter = dRG.HasValue ?
                new ObjectParameter("DRG", dRG) :
                new ObjectParameter("DRG", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GenerateBundleReport", facilityIdParameter, userIDParameter, reportTypeParameter, fromDateParameter, endDateParameter, dRGParameter);
        }
    
        public virtual int GenerateScoreCardReport(Nullable<int> facilityId, Nullable<int> userID, Nullable<int> reportType, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> endDate)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var reportTypeParameter = reportType.HasValue ?
                new ObjectParameter("ReportType", reportType) :
                new ObjectParameter("ReportType", typeof(int));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GenerateScoreCardReport", facilityIdParameter, userIDParameter, reportTypeParameter, fromDateParameter, endDateParameter);
        }

        //public System.Data.Entity.DbSet<ThinkAnew.BundledBroker.UI.Models.GroupViewModel> GroupViewModels { get; set; }
    }
}