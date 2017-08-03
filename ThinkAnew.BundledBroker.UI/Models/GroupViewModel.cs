using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThinkAnew.BundledBroker.UI.Models
{
    public class GroupViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Editable(false)]
        [ReadOnly(true)]
        [Display(Name = "ID")]
        public int GroupId { get; set; }

        [Required]
        [Display(Name="Name")]
        public string GroupName { get; set; }

        [Required]
        [Display(Name = "Max Users")]
        public int MaxAllowedUsers { get; set; }

        [Required]
        [Display(Name = "Max Facilities")]
        public int  MaxAllowedFacilities { get; set; }

        [Required]
        [Display(Name = "Agree to BAA")]
        public bool AgreedToBaa { get; set;}

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }
    }
}