using System;
using System.Collections.Generic;
using System.Text;

namespace MBDVC.WAPISecurity.Models
{
    public class Order : Base
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
