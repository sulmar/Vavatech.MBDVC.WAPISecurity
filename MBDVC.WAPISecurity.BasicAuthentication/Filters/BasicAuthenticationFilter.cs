using MBDVC.WAPISecurity.BasicAuthentication.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace MBDVC.WAPISecurity.BasicAuthentication.Filters
{
    public class BasicAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var authorization = context.Request.Headers.Authorization;

            if (authorization == null)
            {
                return;
            }

            if (authorization.Scheme != "Basic")
            {
                return;
            }

            var result = Extract(authorization.Parameter);

            // Walidacja
            if (result.username != "user" || result.passsword != "P@ssw0rd")
            {
                return;
            }

            Claim claim = new Claim("blabla", "1234");

            Claim claimName = new Claim(ClaimTypes.Name, result.username);
            Claim claimEmail = new Claim(ClaimTypes.Email, "marcin.sulecki@gmail.com");
            Claim claimPhone = new Claim(ClaimTypes.MobilePhone, "609851649");
            Claim claimRole1 = new Claim(ClaimTypes.Role, "admin");
            Claim claimRole2 = new Claim(ClaimTypes.Role, "user");

            var claims = new List<Claim> { claim, claimName, claimEmail, claimPhone, claimRole1, claimRole2 };

            IIdentity identity = new ClaimsIdentity(claims, "Basic");

            IPrincipal principal = new ClaimsPrincipal(identity);

            context.Principal = principal;

            // context.Principal = new GenericPrincipal(new GenericIdentity(result.username), new string[] { "user", "admin" });

        }

        //private Tuple<string, string> Extract(string parameter)
        //{

        //    return new Tuple<string, string>("user1", "password");
        //}

        private (string username, string passsword) Extract(string parameter)
        {

            var credentialBytes = Convert.FromBase64String(parameter);

            var decodedCredentials = Encoding.ASCII.GetString(credentialBytes);

            var index = decodedCredentials.IndexOf(':');

            string username = decodedCredentials.Substring(0, index );
            string password = decodedCredentials.Substring(index + 1);

            return (username, password);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new BasicChallengeResult(context.Result, "sales");

            return Task.FromResult(0);
        }
    }
}