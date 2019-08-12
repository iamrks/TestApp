using System.Threading.Tasks;
using System.Web.Http;
using TestApp.BusinessLogic.Infrastructure.Interfaces;
using TestApp.Models;

namespace TestApp.Api.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        IUnitOfWork _uow;
        public ProductController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_uow.ProductRepository.GetAll());
        }

        [Route("groupByCategory")]
        [HttpGet]
        public IHttpActionResult GroupByCategory()
        {
            return Ok(_uow.ProductRepository.GroupByCategory());
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _uow.ProductRepository.Get(id));
        }


        [Route("")]
        public IHttpActionResult Post(Product product)
        {
            var res = _uow.ProductRepository.Add(product);
            return Ok(res);
        }

        [Route("{:productId}")]
        [HttpPut]
        public IHttpActionResult Put(Product product, int productId)
        {
            _uow.ProductRepository.Update(product);
            return Ok();
        }
    }
}
