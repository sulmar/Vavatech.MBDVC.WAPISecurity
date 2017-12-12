using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using MBDVC.WAPISecurity.IServices;

namespace MBDVC.WAPISecurity.TokenAuthentication.Providers
{
    public class ServiceAuthorizeServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthService authService;

        public ServiceAuthorizeServerProvider(IAuthService authService)
        {
            this.authService = authService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var userProfile = await authService.Find(context.UserName, context.Password);

            if (userProfile == null)
            {
                context.SetError("invalid_grant", "The username or password is invalid");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            context.Validated(identity);

        }
    }
}