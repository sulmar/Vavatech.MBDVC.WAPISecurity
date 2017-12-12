using System;
using System.Collections.Generic;
using System.Text;

namespace MBDVC.WAPISecurity.Models
{
    public class UserProfile
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Person Person { get; set; }
    }
}
