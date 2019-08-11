using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Api.Providers
{
    public class AppAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var userManger = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManger.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "invalid credentials");
                context.Rejected();
                return;
            }

            ClaimsIdentity identity = await AddClaims(context, userManger, user);

            context.Validated(identity);
        }

        private static async Task<ClaimsIdentity> AddClaims(OAuthGrantResourceOwnerCredentialsContext context, ApplicationUserManager userManger, ApplicationUser user)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id));

            var roles = await userManger.GetRolesAsync(user.Id);

            if (roles != null && roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }

            return identity;
        }
    }
}