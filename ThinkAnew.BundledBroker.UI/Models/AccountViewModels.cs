using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ThinkAnew.BundledBroker.UI.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string Password1 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(@"Password1", ErrorMessage = @"Passwords mismatch")]
        public string Password2 { get; set; }
    }

    public class UserViewModel
    {
        #region UserLogins
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = @"User Id")]
        [Editable(false)]
        public int UserId { get; set; }

        [Required]
        [Display(Name = @"Email", Description = @"Your username is an email address")]
        [DataType(DataType.EmailAddress)]
        public string UserName1 { get; set; }

        [Required]
        [Display(Name = @"Confirm Email")]
        [DataType(DataType.EmailAddress)]
        public string UserName2 { get; set; }
    
        [Required]
        [Display(Name = @"Password")]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }

        [Required]
        [Display(Name = @"Confirm Password")]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }

        [Required]
        [Display(Name = @"Creation Date")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Display(Name = @"Last Login")]
        [DataType(DataType.Date)]
        public DateTime LastLoginDate { get; set; }

        [Display(Name = @"Reset Id")]
        public Guid? ResetIdentifier { get; set; }

        [Display(Name = @"Active")]
        public bool UserIsActive { get; set; }
        #endregion

        #region Users

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Phone { get; set; }

        #endregion

        [Display(Name = @"Roles")]
        public IEnumerable<RoleViewModel> UserRoles { get; set; }

        [Display(Name = @"Groups")]
        public IEnumerable<int> UserGroups { get; set; }

    }

    public class UserRoleViewModel
    {
        public int? UserRoleId { get; set; }
        public int? UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}