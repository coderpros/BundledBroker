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
    
    public partial class UserFacility
    {
        public int UserFacilityid { get; set; }
        public int UserId { get; set; }
        public int FacilityId { get; set; }
    
        public virtual Facility Facility { get; set; }
        public virtual User User { get; set; }
    }
}