using MBDVC.WAPISecurity.IServices;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MBDVC.WAPISecurity.TokenAuthentication.Providers
{


    // Install-Package Microsoft.Aspnet.Identity.Owin
    // Install-Package Microsoft.Aspnet.Identity.EntityFramework

    public class DbAuthorizeServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthenticationService authService;

        public DbAuthorizeServerProvider(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identityUser = await authService.Find(context.UserName, context.Password);

            if (identityUser == null)
            {
                context.SetError("invalid_grant", "The username or password is invalid");
                return;
            }

            Claim claimName = new Claim("sub", context.UserName);
            Claim claimEmail = new Claim(ClaimTypes.Email, identityUser.Email);
            Claim claimPhone = new Claim(ClaimTypes.MobilePhone, identityUser.PhoneNumber);


            Claim claimRole1 = new Claim(ClaimTypes.Role, "admin");
            Claim claimRole2 = new Claim(ClaimTypes.Role, "user");

            var claims = new List<Claim> { claimName, claimEmail, claimPhone, claimRole1, claimRole2 };

            var identity = new ClaimsIdentity(claims, context.Options.AuthenticationType);

            context.Validated(identity);
        }
    }
}