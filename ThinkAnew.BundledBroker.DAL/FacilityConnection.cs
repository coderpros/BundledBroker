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
    
    public partial class FacilityConnection
    {
        public int FacilityConnectionId { get; set; }
        public int FacilityId { get; set; }
        public Nullable<int> ConnectionTypeId { get; set; }
        public string ConnectionString { get; set; }
        public string SQLServerName { get; set; }
    
        public virtual ConnectionType ConnectionType { get; set; }
        public virtual Facility Facility { get; set; }
    }
}
