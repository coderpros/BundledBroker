using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace ThinkAnew.Providers.Models
{
    public class CustomMembershipUser : System.Web.Security.MembershipUser
    {
        #region Properties
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Last Login")]
        public DateTime LastLoginDate { get; set; }

        [Required]
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password1 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(@"Password1", ErrorMessage = @"Password mismatch")]
        public string Password2 { get; set; }

        public override string ProviderName => Membership.Provider.Name;
        
        #endregion

        #region Instantiator

        public CustomMembershipUser()
        {
            
        }

        public CustomMembershipUser(string providername,
            string username,
            object providerUserKey,
            string email,
            string passwordQuestion,
            string comment,
            bool isApproved,
            bool isLockedOut,
            DateTime creationDate,
            DateTime lastLoginDate,
            //DateTime lastActivityDate,
            //DateTime lastPasswordChangedDate,
            //DateTime lastLockedOutDate,
            string firstName,
            string lastName,
            string phone) :
            base(providername,
                username,
                providerUserKey,
                email,
                passwordQuestion,
                comment,
                isApproved,
                isLockedOut,
                creationDate,
                lastLoginDate,
                new DateTime(), 
                new DateTime(), 
                new DateTime())
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.CreationDate = creationDate;
            this.LastLoginDate = lastLoginDate;
            this.Email = email;
        }
        #endregion
    }
}