using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MBDVC.WAPISecurity.GoogleAuthentication.Startup))]

// https://console.developers.google.com/apis/
namespace MBDVC.WAPISecurity.GoogleAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
