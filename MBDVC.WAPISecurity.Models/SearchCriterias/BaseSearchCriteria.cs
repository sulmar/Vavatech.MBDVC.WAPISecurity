using System;
using System.Collections.Generic;
using System.Text;

namespace MBDVC.WAPISecurity.Models.SearchCriterias
{
    public abstract class BaseSearchCriteria : Base
    {
    }

    public class PeriodSearchCriteria : BaseSearchCriteria
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }

    public class OrderSearchCriteria : PeriodSearchCriteria
    {
        public bool IsDeleted { get; set; }
    }
}
