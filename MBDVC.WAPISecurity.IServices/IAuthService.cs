using MBDVC.WAPISecurity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MBDVC.WAPISecurity.IServices
{
    public interface IAuthService
    {
        Task<UserProfile> Register(UserProfile person);

        Task<UserProfile> Find(string username, string password);
    }
}
