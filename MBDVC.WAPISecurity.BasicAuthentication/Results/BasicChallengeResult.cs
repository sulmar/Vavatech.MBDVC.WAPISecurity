﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MBDVC.WAPISecurity.BasicAuthentication.Results
{
    public class BasicChallengeResult : IHttpActionResult
    {
        private IHttpActionResult innerResult;
        private string realm;

        public BasicChallengeResult(IHttpActionResult innerResult, string realm = null)
        {
            this.innerResult = innerResult;
            this.realm = realm;

        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await innerResult.ExecuteAsync(cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                if (string.IsNullOrEmpty(realm))
                {
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic"));
                }
                else
                {
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", $"realm=\"{realm}\""));
                }
            }

            return response;
            

        }
    }
}