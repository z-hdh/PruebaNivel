using Prueba.Aplication.Dto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba.Application.Services
{
    public interface IProductServices
    {
        ProductDTO AddProduct(ProductDTO product);

        List<ProductDTO> GetProducts();

        ProductDTO GetProductById(int id)
;
        ProductDTO GetProductByName(string name);

        ProductDTO DeleteProductById(int id);

        void NotifyExpiredProducts();
    }
}
