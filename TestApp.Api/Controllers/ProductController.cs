using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Http;
using TestApp.Api.Filters;
using TestApp.Data;

namespace TestApp.Api.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : BaseApiController
    {
        [CustomAuthorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            var name = RequestContext.Principal.Identity.GetUserName();
            var req = RequestContext.Principal.Identity as ClaimsIdentity;
            var id = req.FindFirst(ClaimTypes.Sid);
            return Ok(Product.DummyProducts());
        }
    }
}
