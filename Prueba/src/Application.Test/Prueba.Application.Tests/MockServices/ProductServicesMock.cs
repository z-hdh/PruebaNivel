using Moq;
using Prueba.Aplication.Dto.DTOs;
using Prueba.Application.Services;
using Prueba.Application.Unit.Tests.Stubs;

namespace Prueba.Application.Unit.Tests.MockServices
{
    public class ProductServicesMock
    {
        public Mock<IProductServices> _productServices { get; set; }

        public ProductServicesMock()
        {
            _productServices = new Mock<IProductServices>();
        }

        private void Setup()
        {
            //AddProduct
            _productServices.Setup(x => x.AddProduct(It.IsAny<ProductDTO>())).Returns(ProductStub.productDTO);
            //GetProductById
            _productServices.Setup(x => x.GetProductById(It.IsAny<int>())).Returns(ProductStub.productDTO);
            // GetProductByName
            _productServices.Setup(x => x.GetProductByName(It.IsAny<string>())).Returns(ProductStub.productDTO);
            // DeleteProductById
            _productServices.Setup(x => x.DeleteProductById(It.Is<int>(p => p.Equals(It.IsAny<int>())))).Returns(ProductStub.productDTO);

        }
    }
}
