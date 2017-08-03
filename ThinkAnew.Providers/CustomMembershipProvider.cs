using System;
using System.Configuration.Provider;
using System.Linq;
using System.Web.Security;
using ThinkAnew.BundledBroker.DAL;
//using ThinkAnew.BundledBroker.UI.Models;

namespace ThinkAnew.Providers
{
    public class CustomMembershipProvider : System.Web.Security.MembershipProvider
    {
        private ThinkAnew.BundledBroker.DAL.BundledBrokerEntities _dbContext = new ThinkAnew.BundledBroker.DAL.BundledBrokerEntities();

        public CustomMembershipProvider()
        {

        }

        public CustomMembershipProvider(bool enablePasswordRetrieval, bool enablePasswordReset, bool requiresQuestionAndAnswer, int maxInvalidPasswordAttempts, int passwordAttemptWindow, bool requiresUniqueEmail, MembershipPasswordFormat passwordFormat, int minRequiredPasswordLength, int minRequiredNonAlphanumericCharacters, string passwordStrengthRegularExpression)
        {
            EnablePasswordRetrieval = enablePasswordRetrieval;
            EnablePasswordReset = enablePasswordReset;
            RequiresQuestionAndAnswer = requiresQuestionAndAnswer;
            MaxInvalidPasswordAttempts = maxInvalidPasswordAttempts;
            PasswordAttemptWindow = passwordAttemptWindow;
            RequiresUniqueEmail = requiresUniqueEmail;
            PasswordFormat = passwordFormat;
            MinRequiredPasswordLength = minRequiredPasswordLength;
            MinRequiredNonAlphanumericCharacters = minRequiredNonAlphanumericCharacters;
            PasswordStrengthRegularExpression = passwordStrengthRegularExpression;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            UserLogin userLogin = new UserLogin()
            {
                UserId = Convert.ToInt32(providerUserKey),
                UserName = username,
                Password = password,
                CreationDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
                UserIsActive = true,
            };

            _dbContext.UserLogins.Add(userLogin);
            _dbContext.SaveChanges();

            status = MembershipCreateStatus.Success;

            return new MembershipUser("CustomMembershipProvider", username, userLogin.UserId, username, passwordQuestion, "", true, false, userLogin.CreationDate, userLogin.LastLoginDate, DateTime.Now, DateTime.Now, DateTime.Now);
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            Models.CustomMembershipUser customUser = user as Models.CustomMembershipUser;

            var userLogin = _dbContext.UserLogins.First(ul => ul.UserName == customUser.Email);

            userLogin.UserName = customUser.Email;
            userLogin.User.Email = customUser.Email;
            userLogin.User.FirstName = customUser.FirstName;
            userLogin.User.LastName = customUser.LastName;
            userLogin.User.Phone = customUser.Phone;

            _dbContext.SaveChanges();


        }

        public override bool ValidateUser(string username, string password)
        {
            return _dbContext.UserLogins.Any(ul => ul.UserName == username && ul.Password == password);
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            username = string.IsNullOrEmpty(username) ? System.Web.HttpContext.Current.User.Identity.Name : username;

            try
            {
                ThinkAnew.BundledBroker.DAL.UserLogin userLogin =
                    _dbContext.UserLogins.FirstOrDefault(ul => ul.UserName == username);

                MembershipUser user = new Models.CustomMembershipUser(@"CustomMembershipProvider",
                    username,
                    userLogin.UserId,
                    userLogin.User.Email,
                    "",
                    "",
                    userLogin.UserIsActive,
                    false,
                    userLogin.CreationDate,
                    userLogin.LastLoginDate,
                    userLogin.User.FirstName,
                    userLogin.User.LastName,
                    userLogin.User.Phone);

                return user;
            }
            catch (Exception ex)
            {
                throw new ProviderException(ex.Message, ex.InnerException);
            }
        }

        public override string GetUserNameByEmail(string email)
        {
            try
            {
                ThinkAnew.BundledBroker.DAL.UserLogin user =
                    _dbContext.UserLogins.FirstOrDefault(ul => ul.User.Email == email);

                return user.UserName;

            }
            catch (Exception ex)
            {
                throw new ProviderException(ex.Message, ex.InnerException);
            }
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public void LogAccess(int userId, string ipAddress)
        {
            _dbContext.UserLogins.First(ul => ul.UserId == userId).LastLoginDate = DateTime.Now;

            _dbContext.LoginHistories.Add(new ThinkAnew.BundledBroker.DAL.LoginHistory()
            {
                IPAddress = ipAddress,
                LoginDate = DateTime.Now,
                Userid = userId
            });
            
            _dbContext.SaveChanges();
        }

        public override bool EnablePasswordRetrieval { get; }
        public override bool EnablePasswordReset { get; }
        public override bool RequiresQuestionAndAnswer { get; }
        public override string ApplicationName { get; set; }
        public override int MaxInvalidPasswordAttempts { get; }
        public override int PasswordAttemptWindow { get; }
        public override bool RequiresUniqueEmail { get; }
        public override MembershipPasswordFormat PasswordFormat { get; }
        public override int MinRequiredPasswordLength { get; }
        public override int MinRequiredNonAlphanumericCharacters { get; }
        public override string PasswordStrengthRegularExpression { get; }
    }
}