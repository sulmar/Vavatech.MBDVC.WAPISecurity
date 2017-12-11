using MBDVC.WAPISecurity.IServices;
using MBDVC.WAPISecurity.MockServices;
using MBDVC.WAPISecurity.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MBDVC.WAPISecurity.BasicAuthentication.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrdersService ordersService;

        public OrdersController()
            : this(new MockOrdersService())
        {

        }

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IHttpActionResult Get() => Ok(ordersService.Get());


        [Authorize(Roles = "admin")]
        public IHttpActionResult Get(int id)
        {
            var order = ordersService.Get(id);

            if (order==null)
            {
                return NotFound();
            }

            return Ok(order);
        }


        //public IHttpActionResult Get([FromUri] OrderSearchCriteria searchCriteria)
        //{
        //    var orders = ordersService.Get(searchCriteria);

        //    if (!orders.Any())
        //    {
        //        return NotFound();
        //    }

        //    return Ok();
        //}
    }
}