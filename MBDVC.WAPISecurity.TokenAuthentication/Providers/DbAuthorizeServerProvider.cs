using MBDVC.WAPISecurity.IServices;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MBDVC.WAPISecurity.TokenAuthentication.Providers
{


    // Install-Package Microsoft.Aspnet.Identity.Owin
    // Install-Package Microsoft.Aspnet.Identity.EntityFramework

    public class DbAuthorizeServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthService authService;


        public DbAuthorizeServerProvider(IAuthService authService)
        {
            this.authService = authService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

        }
    }
}