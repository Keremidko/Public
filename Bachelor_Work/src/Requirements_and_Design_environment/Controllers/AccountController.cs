using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebMatrix.WebData;
using Requirements_and_Design_environment.Models.Entities;
using Requirements_and_Design_environment.Models.Interfaces;
using Requirements_and_Design_environment.Models.Repositories;

namespace Requirements_and_Design_environment.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        private IUsersRepository usersRepository { get; set; }

        public AccountController()
        {
            usersRepository = new UsersRepository();
        }

        [HttpPost]
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public IHttpActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return Ok();
            }

            return BadRequest("The user name or password provided is incorrect.");
        }

        [HttpPost]
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public IHttpActionResult Register(RegisterModel model)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    WebSecurity.Login(model.UserName, model.Password);
                    return Ok();
                }
                catch (MembershipCreateUserException e)
                {
                    message = ErrorCodeToString(e.StatusCode);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                }
            }
            else {
                message = "Incorrect input data. User name is mandatory, password should be atleast 6 symbols, and both password should match.";
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(message);
        }

        [HttpGet]
        [AllowAnonymous]
        public bool IsUserLogged()
        {
            return WebSecurity.IsAuthenticated;
        }

        [HttpGet]
        public object GetProfile()
        {
            UserProfile user = usersRepository.GetCurrentUserProfile();
            var projects = from p in user.Participations
                           //Избира всички проекти в които участва user-a
                           select new
                           {
                               ID = p.ProjectID,
                               AccessLevel = p.AccessLevel,
                               Name = p.ProjectReference.Name,
                               Visibility = p.ProjectReference.Visibility,
                               //избира всички user-и които участват в проекта на user-a
                               Participants = from par in p.ProjectReference.Participations
                                              select new
                                              {
                                                  UserName = par.UserReference.UserName,
                                                  AccessLevel = par.AccessLevel,
                                              }
                           };
            var viewModel = new
            {
                UserName = user.UserName,
                Projects = projects
            };
            return viewModel;
        }
    
        [HttpGet]
        public string[] GetUsersByName(string name)
        {
            return usersRepository.GetUsersByName(name);
        }

        [HttpPost]
        public IHttpActionResult LogOut()
        {
            WebSecurity.Logout();
            return Ok();
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}
