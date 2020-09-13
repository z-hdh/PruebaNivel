using FluentAssertions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prueba.Application.Helpers;
using Prueba.Application.Services;
using Prueba.Application.Unit.Tests.MockHelpers;
using Prueba.Application.Unit.Tests.MockRabbitMQ;
using Prueba.Application.Unit.Tests.MockRepository;
using Prueba.Application.Unit.Tests.Stubs;
using Prueba.Domain.Repositories;


namespace Prueba.Application.Unit.Tests
{
    [TestClass]
    public class ProductServiceTest
    {
        private static IProductServices _productService;

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {
            Mock<IProductRepository> _productRepository = new ProductRepositoryMock()._productRepository;
            Mock<IProductHelper> _productHelper = new MockProductHelper()._productHelper;
            Mock<IOptions<MockAmqpInfo>> _amqpInfo = new MockAmqpInfo()._amqpInfo;
            Mock<Prueba.Services.RabbitMQ.AmqpService> _amqpService = new MockAmqpService()._amqpService;

            _productService = new ProductServices(_productRepository.Object, _productHelper.Object, _amqpService.Object);
        }

        [TestMethod]
        public void addProduct_valid()
        {
            // Arrange

            // Act
            var result = _productService.AddProduct(ProductStub.productDTO);

            // Assert
            result.Id.Should().BePositive();
            result.Code.Should().NotBeNullOrEmpty();
            result.Name.Should().NotBeNullOrEmpty();
            result.Type.Should().NotBeNullOrEmpty();

        }
    }
}
