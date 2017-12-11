using MBDVC.WAPISecurity.IServices;
using MBDVC.WAPISecurity.MockServices;
using MBDVC.WAPISecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MBDVC.WAPISecurity.SecretKeyService.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductsService productsService;

        public ProductsController()
            : this(new MockProductsService())
        {

        }

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IHttpActionResult Get()
        {
            var products = productsService.Get();

            return Ok(products);
        }

        public IHttpActionResult Get(int id)
        {
            var product = productsService.Get(id);

            if (product==null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}