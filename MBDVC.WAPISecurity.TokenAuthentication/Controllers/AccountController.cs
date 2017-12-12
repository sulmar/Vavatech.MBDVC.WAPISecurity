using MBDVC.WAPISecurity.DbServices;
using MBDVC.WAPISecurity.IServices;
using MBDVC.WAPISecurity.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MBDVC.WAPISecurity.TokenAuthentication.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {

        private readonly IAuthenticationService authenticationService;

        public AccountController()
            : this(new DbAuthenticationService())
        {
        }

        public AccountController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }


        // POST /api/Account/Register

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserProfile user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await authenticationService.Register(user);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult!=null)
            {
                return errorResult;
            }

            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result==null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}