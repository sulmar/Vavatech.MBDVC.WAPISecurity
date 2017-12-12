﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBDVC.WAPISecurity.DbServices
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {

        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}
