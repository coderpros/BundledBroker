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
    
    public partial class RevenueCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RevenueCode()
        {
            this.ClaimDetails = new HashSet<ClaimDetail>();
            this.RevenueCodeMultipliers = new HashSet<RevenueCodeMultiplier>();
        }
    
        public int RevenueCodeId { get; set; }
        public string RevenueCode1 { get; set; }
        public string RevenueCodeDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaimDetail> ClaimDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RevenueCodeMultiplier> RevenueCodeMultipliers { get; set; }
    }
}