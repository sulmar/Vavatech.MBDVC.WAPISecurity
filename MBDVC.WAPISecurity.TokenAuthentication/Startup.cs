using MBDVC.WAPISecurity.MockServices;
using MBDVC.WAPISecurity.TokenAuthentication.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MBDVC.WAPISecurity.TokenAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            // config OAuth 2.0
            ConfigureOAuth(app);

            app.UseWebApi(config);
        }


        // Install-Package Microsoft.Owin.Security.OAuth
        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new ServiceAuthorizeServerProvider(new MockAuthService()),
            };

            app.UseOAuthAuthorizationServer(options);

            var tokenOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(tokenOptions);
        }
    }
}