using TestApp.Models;
using TestApp.BusinessLogic.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TestApp.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbCtx): base(dbCtx)
        {
        }

        public void Update(Product product)
        {
            _dbCtx.Products.Attach(product);
            _dbCtx.Entry(product).Property(c => c.Name).IsModified = true;
            _dbCtx.SaveChanges();
        }

        public List<IGrouping<int, Product>> GroupByCategory()
        {
            var res = _dbCtx.Products.GroupBy(c => c.CategoryId).ToList();
            return res;
        }
    }
}
