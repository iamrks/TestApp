using System.Threading.Tasks;
using System.Web.Http;
using TestApp.BusinessLogic.Infrastructure.Interfaces;
using TestApp.Models;

namespace TestApp.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_uow.CategoryRepository.GetAll());
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _uow.CategoryRepository.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Category category)
        {
            var res = _uow.CategoryRepository.Add(category);
            return Ok(res);
        }
    }
}
