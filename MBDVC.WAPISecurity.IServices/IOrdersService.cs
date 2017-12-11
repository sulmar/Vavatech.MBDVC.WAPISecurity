using MBDVC.WAPISecurity.Models;
using MBDVC.WAPISecurity.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBDVC.WAPISecurity.IServices
{
    public interface IOrdersService
    {
        IList<Order> Get();

        Order Get(int id);

        IList<Order> Get(OrderSearchCriteria criteria);

    }
}
