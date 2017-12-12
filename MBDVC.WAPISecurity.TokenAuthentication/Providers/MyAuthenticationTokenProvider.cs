using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace MBDVC.WAPISecurity.TokenAuthentication.Providers
{
    public class MyAuthenticationTokenProvider : IAuthenticationTokenProvider
    {
        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}