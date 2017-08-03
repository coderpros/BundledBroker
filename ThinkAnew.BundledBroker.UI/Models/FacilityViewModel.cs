using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThinkAnew.BundledBroker.UI.Models
{
    public class FacilityViewModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int FacilityId { get; set; }

        [Required]
        [Display(Name="Group ID")]
        public int GroupId { get; set; }
        
        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }

        [Required]
        [Display(Name="County")]
        public int CountyId { get; set; }

        [Required]
        [Display(Name = "Facility Code", ShortName = "Code")]
        public string FacilityCode { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string FacilityName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Display(Name = "Zip")]
        public string Postal { get; set; }

        [Display(Name = "Active")]
        public bool FacilityIsActive { get; set; }

        [Display(Name = "Group")]
        public string GroupName { get; set; }

        [Display(Name = "Last Claim Date")]
        public DateTime? LastClaimDate { get; set; }

        public DateTime? LastPullDate { get; set; }

        //public DAL.Group Group { get; set; }

        /*

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AHTFacilityConnection> AHTFacilityConnections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendingPhysician> AttendingPhysicians { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaimDetail> ClaimDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Claim> Claims { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Episode> Episodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFacility> UserFacilities { get; set; }
        public virtual Group Group { get; set; }
        public virtual State State { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacilityConnection> FacilityConnections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacilityLookup> FacilityLookups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacilityPullData> FacilityPullDatas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReferringHospital> ReferringHospitals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resident> Residents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RevenueCodeMultiplier> RevenueCodeMultipliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoutineCostOfCare> RoutineCostOfCares { get; set; }
        */
    }
}