using TestApp.BusinessLogic.Infrastructure.Interfaces;
using TestApp.Models;

namespace TestApp.Data.Repositories
{
    class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbctx): base(dbctx)
        {

        }
    }
}
