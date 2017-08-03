using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using ThinkAnew.BundledBroker.UI.Models;
using Umbraco.Web.Mvc;

namespace ThinkAnew.BundledBroker.UI.Controllers
{
    public class AccountController : BaseSurfaceController
    {
        ThinkAnew.BundledBroker.BLL.Account _bllAccount = new BLL.Account();

        public ActionResult ChangeLanguage(string lang)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);

            var url = System.Web.HttpContext.Current.Request.UrlReferrer;

            Response.Redirect(url.ToString());

            return Content("");
        }

        //
        //POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var valid = Membership.ValidateUser(model.UserName, model.Password);

                    if (valid)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, false);

                        //Log to login history. 
                        var membershipUser = Membership.GetUser(model.UserName);

                        if (membershipUser != null)
                            new Providers.CustomMembershipProvider().LogAccess(
                                Convert.ToInt32(membershipUser.ProviderUserKey),
                                Request.ServerVariables["REMOTE_ADDR"]);

                        return RedirectToUmbracoPage(4066);
                    }
                    else
                    {
                        AlertError(@"Invalid username or password.", true);

                        return RedirectToCurrentUmbracoPage();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(@"CustomMessage", $"We are experiencing technical difficulties Please try again later\n{ex.Message}");

                    throw ex;
                }
            }
            else
            {
                return CurrentUmbracoPage();
            }
        }

        //
        //GET: /Account/Logout
        [HttpGet]
        [Authorize]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            FormsAuthentication.SignOut();
            Session.Abandon();

            return Redirect("/");
        }

        //
        //POST: /Account/ForgotPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string Email)
        {
            if (!ModelState.IsValid) return CurrentUmbracoPage();

            try
            {
                Providers.Models.CustomMembershipUser user = Membership.GetUser(Email) as Providers.Models.CustomMembershipUser;

                if (user == null)
                {
                    ModelState.AddModelError(@"CustomMessage",
                        @"No user was found matching that email address.");

                    return CurrentUmbracoPage();
                }
                else
                {
                    //Create unique identifier and update db.
                    Guid resetIdentifier = _bllAccount.ResetPassword(Convert.ToInt32(user.ProviderUserKey));

                    //Send reset email to appropriate user.
                    using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient())
                    {
                        client.Send(new System.Net.Mail.MailMessage(new System.Net.Mail.MailAddress(Properties.Settings.Default.NoReplyEmail), new System.Net.Mail.MailAddress(Email))
                        {
                            Body = $"To reset your account password, please click the following link: \n\n http://{Request.ServerVariables["HTTP_HOST"]}/umbraco/Surface/Account/ResetPassword?id={resetIdentifier.ToString()}",
                            IsBodyHtml = false,
                            Priority = System.Net.Mail.MailPriority.High,
                            Subject = @"Reset Your Bundled Broker Account Password",
                        });
                    }

                }

                //Return success message.
                AlertSuccess($"Please check {Email} for password reset instructions.");
                return CurrentUmbracoPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(@"CustomMessage",
                    $"We are experiencing technical difficulties Please try again later\n{ex.Message}");

                return CurrentUmbracoPage();
            }
        }

        //
        //GET: /Account/ResetPassword?id=0
        [HttpGet]
        public ActionResult ResetPassword(string id)
        {
            return RedirectToUmbracoPage(2062, new NameValueCollection()
            {
                {"id", id}
            });
        }

        //
        //POST: /Account/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(Models.ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return CurrentUmbracoPage();

            _bllAccount.ResetPassword(model.Id, model.Password1);

            AlertSuccess(@"Your password was successfully reset.");

            return Redirect(@"/");
        }

        //
        //POST: /Account/Manage
        [HttpPost]
        public ActionResult Manage(Providers.Models.CustomMembershipUser model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();
            else
                try
                {
                    if (User.Identity.IsAuthenticated)
                        Membership.UpdateUser(model);
                    else
                    {
                        int userId = _bllAccount.CreateUser(model.Email, model.Phone, model.FirstName, model.LastName);

                        MembershipCreateStatus creationStatus;

                        MembershipUser user = Membership.CreateUser(model.Email, model.Password1, model.Email, null, null,
                            true, userId, out creationStatus);

                        if (creationStatus == MembershipCreateStatus.Success)
                        {
                            Roles.AddUserToRole(model.Email, "User");

                            AlertSuccess("Account successfully created.");
                        }
                        else
                        {
                            AlertWarning("Account could not be created.");
                        }
                    }

                    AlertSuccess("Account sucessfully updated.");

                    return RedirectToCurrentUmbracoPage();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(@"CustomMessage",
                        $"We are experiencing technical difficulties Please try again later\n{ex.Message}");

                    return RedirectToCurrentUmbracoPage();
                }
        }


        #region Child Actions
        //
        //GET: /Account/ManageGeneral
        [HttpGet]
        [ChildActionOnly]
        public ActionResult CreateManageGeneral()
        {
            return PartialView(@"~/Views/Partials/Account/ManageGeneral.cshtml", new Providers.Models.CustomMembershipUser());
        }

        [HttpGet]
        [Authorize]
        [ChildActionOnly]
        public ActionResult ManageGeneral(Providers.Models.CustomMembershipUser model)
        {
            return PartialView(@"~/Views/Partials/Account/ManageGeneral.cshtml", model);
        }

        //
        //GET: /Account/ResetPasswordForm
        [HttpGet]
        [ChildActionOnly]
        public ActionResult ResetPasswordForm()
        {
            return PartialView(@"~/Views/Partials/Account/ResetPasswordForm.cshtml", new Models.ResetPasswordViewModel());
        }

        //
        //GET: /Account/StandardLoginForm
        [HttpGet]
        [ChildActionOnly]
        public ActionResult StandardLoginForm()
        {
            return PartialView(@"~/Views/Partials/Account/StandardLoginForm.cshtml", new Models.LoginViewModel());
        }

        //
        //GET: /Account/Manage
        [HttpGet]
        [Authorize]
        [ChildActionOnly]
        public ActionResult Manage()
        {
            return PartialView(@"~/Views/Partials/Account/Manage.cshtml", Membership.GetUser() as Providers.Models.CustomMembershipUser);
        }

        //
        //GET: /Account/Register
        [HttpGet]
        [ChildActionOnly]
        public ActionResult Register()
        {
            return PartialView(@"~/Views/Partials/Account/Manage.cshtml", new Providers.Models.CustomMembershipUser());
        }
        #endregion
    }
}