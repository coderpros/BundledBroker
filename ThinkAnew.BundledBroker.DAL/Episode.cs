//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Episode
    {
        public int EpisodeId { get; set; }
        public int FacilityId { get; set; }
        public int ResidentId { get; set; }
        public int ClaimId { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> ReferringHospitalId { get; set; }
        public Nullable<int> AttendingPhysicianId { get; set; }
    
        public virtual AttendingPhysician AttendingPhysician { get; set; }
        public virtual Claim Claim { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual ReferringHospital ReferringHospital { get; set; }
        public virtual Resident Resident { get; set; }
    }
}