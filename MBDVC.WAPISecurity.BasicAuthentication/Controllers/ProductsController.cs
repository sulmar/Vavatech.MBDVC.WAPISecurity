using MBDVC.WAPISecurity.BasicAuthentication.Filters;
using MBDVC.WAPISecurity.IServices;
using MBDVC.WAPISecurity.MockServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace MBDVC.WAPISecurity.BasicAuthentication.Controllers
{
    [Authorize]
    [BasicAuthenticationFilter]
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

            var principal = this.User as ClaimsPrincipal;

            if (principal.HasClaim(c=>c.Type == ClaimTypes.Email))
            {
                var email = principal.Claims.First(c => c.Type == ClaimTypes.Email).Value;

                // TODO: send email
            }

            var products = productsService.Get();

            if (!this.User.IsInRole("admin"))
            {
                products = products.Where(p => !p.IsDeleted).ToList();
            }
            
           

            return Ok(products);
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            var product = productsService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}