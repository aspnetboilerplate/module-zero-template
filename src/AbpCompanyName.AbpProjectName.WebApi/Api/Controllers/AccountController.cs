using System;
using System.Threading.Tasks;
using Abp.WebApi.Controllers;
using AbpCompanyName.AbpProjectName.Users;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace AbpCompanyName.AbpProjectName.Api.Controllers
{
    public class AccountController : AbpApiController
    {
        private readonly UserManager _userManager;
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        static AccountController ()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        public AccountController(UserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return "FAILED";
            }

            var userIdentity = await _userManager.FindAsync(username, password);
            if (userIdentity == null)
            {
                return "FAILED";
            }

            var identity = await _userManager.CreateIdentityAsync(userIdentity, OAuthBearerOptions.AuthenticationType);
            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());

            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

            return OAuthBearerOptions.AccessTokenFormat.Protect(ticket);
        }
    }
}
