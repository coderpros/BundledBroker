using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkAnew.BundledBroker.BLL
{
    public class Account
    {
        private readonly ThinkAnew.BundledBroker.DAL.BundledBrokerEntities _dbContext = new ThinkAnew.BundledBroker.DAL.BundledBrokerEntities();

        #region Constructor
        public Account()
        {

        }
        #endregion

        public Guid ResetPassword(int userId)
        {
            Guid resetIdentifier = Guid.NewGuid();

            DAL.UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault(ul => ul.UserId == userId);

            if (userLogin == null) resetIdentifier = Guid.Empty;
            else
            {
                userLogin.ResetIdentifier = resetIdentifier;

                _dbContext.SaveChanges();
            }

            return resetIdentifier;
        }

        public void ResetPassword(Guid resetIdentifier, string password)
        {
            DAL.UserLogin userLogin = _dbContext.UserLogins.First(ul => ul.ResetIdentifier == resetIdentifier);
            
            userLogin.Password = password;
            userLogin.ResetIdentifier = null;

            _dbContext.SaveChanges();
        }

        public int CreateUser(string emailAddress, string phoneNumber, string firstName, string lastName)
        {
            DAL.User user = new DAL.User()
            {
                Email = emailAddress,
                FirstName = firstName,
                LastName = lastName,
                Phone = phoneNumber,
                UserIsActive = true
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.UserId;
        }

        public IQueryable<DAL.UserLogin> GetUsers()
        {
            return _dbContext.UserLogins;
        }
    }
}
