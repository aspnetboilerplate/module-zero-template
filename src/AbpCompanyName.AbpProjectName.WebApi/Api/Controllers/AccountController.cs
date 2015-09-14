using System;
using System.Threading.Tasks;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using AbpCompanyName.AbpProjectName.Users;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace AbpCompanyName.AbpProjectName.Api.Controllers
{
    public class AccountController : AbpApiController
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        private readonly UserManager _userManager;

        static AccountController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        public AccountController(UserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<AjaxResponse> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return new AjaxResponse(new ErrorInfo("username and password can not be empty"));
            }

            var userIdentity = await _userManager.FindAsync(username, password);
            if (userIdentity == null)
            {
                return new AjaxResponse(new ErrorInfo("Invalid user name or password."));
            }

            var identity = await _userManager.CreateIdentityAsync(userIdentity, OAuthBearerOptions.AuthenticationType);
            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());

            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

            return new AjaxResponse(OAuthBearerOptions.AccessTokenFormat.Protect(ticket));
        }
    }
}
