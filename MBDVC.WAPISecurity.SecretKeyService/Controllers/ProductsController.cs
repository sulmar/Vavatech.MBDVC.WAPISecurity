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

        public IList<Product> Get()
        {
            return productsService.Get();
        }

        public Product Get(int id)
        {
            return productsService.Get(id);
        }
    }
}