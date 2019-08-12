using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestApp.Models;

namespace TestApp.BusinessLogic.Infrastructure.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
        List<IGrouping<int, Product>> GroupByCategory();
    }
}
