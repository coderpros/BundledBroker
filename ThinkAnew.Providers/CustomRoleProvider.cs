using System;
using System.Linq;
using System.Web.Security;
using ThinkAnew.BundledBroker.DAL;

namespace ThinkAnew.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private ThinkAnew.BundledBroker.DAL.BundledBrokerEntities _dbContext = new ThinkAnew.BundledBroker.DAL.BundledBrokerEntities();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (string sUser in usernames)
            {
                var user = _dbContext.UserLogins.First(ul => ul.UserName == sUser);

                foreach (string sRole in roleNames)
                {
                    var role = _dbContext.Roles.First(r => r.RoleName == sRole);

                    _dbContext.UserRoles.Add(new UserRole()
                    {
                        RoleId = role.RoleId,
                        UserId = user.UserId
                    });

                    _dbContext.SaveChanges();
                }
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return _dbContext.Roles.Select(r => r.RoleName).ToArray();

        }

        public override string[] GetRolesForUser(string username)
        {
            return _dbContext.UserRoles.Where(ur => ur.User.UserLogin.UserName == username).Select(ur => ur.Role.RoleName).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}