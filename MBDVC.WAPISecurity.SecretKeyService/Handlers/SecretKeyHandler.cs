using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MBDVC.WAPISecurity.SecretKeyService.Handlers
{
    public class SecretKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var isValid = ValidateKey(request);

            if (isValid)
            {
                return await base.SendAsync(request, cancellationToken);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }

            
        }

        private bool ValidateKey(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("secret-key", out IEnumerable<string> values))
            {
                return values.Contains("1234");
            }
            else
                return false;

        }
    }
}