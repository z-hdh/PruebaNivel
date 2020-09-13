using Moq;
using Prueba.Application.Unit.Tests.Stubs;
using Prueba.Domain.Entities;
using Prueba.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Application.Unit.Tests.MockRepository
{
    public class ProductRepositoryMock
    {
        public Mock<IProductRepository> _productRepository { get; set; }

        public ProductRepositoryMock()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        private void Setup()
        {
            // AddProduct
            _productRepository.Setup(x => x.AddProduct(It.IsAny<Product>())).Returns(ProductStub.product);
            // DeleteProduct
            _productRepository.Setup(x => x.DeleteProduct(It.IsAny<int>())).Returns(ProductStub.product);
            // Get
            _productRepository.Setup(x => x.Get(p => p.Id == 4, null, null)).Returns(new List<Product>() { ProductStub.product });
        }
    }
}
