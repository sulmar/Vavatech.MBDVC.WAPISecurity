using MBDVC.WAPISecurity.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using MBDVC.WAPISecurity.Models;
using MBDVC.WAPISecurity.Models.SearchCriterias;
using System.Linq;

namespace MBDVC.WAPISecurity.MockServices
{
    public class MockOrdersService : IOrdersService
    {
        private IList<Order> orders;

        public MockOrdersService()
        {
            orders = new List<Order>
            {
                new Order { Id=1, Number ="001", OrderDate = DateTime.Today },
                new Order { Id=2, Number ="002", OrderDate = DateTime.Today },
                new Order { Id=3, Number ="003", OrderDate = DateTime.Today },
                new Order { Id=4, Number ="004", OrderDate = DateTime.Today },
                new Order { Id=5, Number ="005", OrderDate = DateTime.Today },
            };
        }

        public IList<Order> Get() => orders;

        public Order Get(int id) => orders.SingleOrDefault(o => o.Id == id);

        public IList<Order> Get(OrderSearchCriteria criteria) => orders
                .Where(o => o.OrderDate >= criteria.From)
                .Where(o => o.OrderDate <= criteria.To)
                .ToList();
    }
}
