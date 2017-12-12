using MBDVC.WAPISecurity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace MBDVC.WAPISecurity.IServices
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> Register(UserProfile userProfile);

        Task<IdentityUser> Find(string username, string password);
    }
}
