using MBDVC.WAPISecurity.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using MBDVC.WAPISecurity.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MBDVC.WAPISecurity.MockServices
{
    public class MockAuthService : IAuthService
    {
        private IList<UserProfile> userProfiles = new List<UserProfile>()
        {
            new UserProfile { Login = "marcin" , Password = "1234"},
            new UserProfile { Login = "user" , Password = "P@ssword"},
        };

        public Task<UserProfile> Find(string username, string password)
        {
            var user = userProfiles
                .SingleOrDefault(p => p.Login == username && p.Password == password);

            return Task.FromResult(user);
        }

        public Task<UserProfile> Register(UserProfile userProfile)
        {
            userProfiles.Add(userProfile);

            return Task.FromResult(userProfile);
        }
    }
}
