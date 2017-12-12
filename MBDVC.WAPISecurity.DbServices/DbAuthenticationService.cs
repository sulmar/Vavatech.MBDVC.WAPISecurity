using MBDVC.WAPISecurity.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBDVC.WAPISecurity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace MBDVC.WAPISecurity.DbServices
{
    public class DbAuthenticationService : IAuthenticationService
    {
        private UserManager<IdentityUser> userManager;

        private AuthContext authContext;

        public DbAuthenticationService()
        {
            authContext = new AuthContext();

            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(authContext));
        }

        public async Task<IdentityUser> Find(string username, string password)
        {
            IdentityUser identityUser = await userManager.FindAsync(username, password);

            return identityUser;
        }

        public async Task<IdentityResult> Register(UserProfile userProfile)
        {
            var passwordHasher = new PasswordHasher();

            var identityUser = new IdentityUser(userProfile.Login);
            identityUser.PasswordHash = passwordHasher.HashPassword(userProfile.Password);
            identityUser.Email = userProfile.Email;
            identityUser.PhoneNumber = userProfile.PhoneNumber;


            //var role1 = new IdentityUserRole { RoleId = "admin", UserId = identityUser.Id };
            //var role2 = new IdentityUserRole { RoleId = "user", UserId = identityUser.Id };

            //identityUser.Roles.Add(role1);
            //identityUser.Roles.Add(role2);
            var result = await userManager.CreateAsync(identityUser);

            return result;

        }
    }
}
