﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MBDVC.WAPISecurity.Models
{
    public class Person : Base
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
