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
    
    public partial class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<System.Guid> ResetIdentifier { get; set; }
        public System.DateTime CreationDate { get; set; }
        public System.DateTime LastLoginDate { get; set; }
        public bool UserIsActive { get; set; }
    
        public virtual User User { get; set; }
    }
}
