using Prueba.Domain.Entities;
using Prueba.Domain.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba.Domain.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product AddProduct(Product product);

        Product DeleteProduct(int id);

        List<Product> GetExpiredProducts();
    }
}
