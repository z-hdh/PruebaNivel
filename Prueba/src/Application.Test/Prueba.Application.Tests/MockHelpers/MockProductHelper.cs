using Moq;
using Prueba.Application.Helpers;

namespace Prueba.Application.Unit.Tests.MockHelpers
{
    public class MockProductHelper
    {
        public Mock<IProductHelper> _productHelper { get; set; }

        public MockProductHelper()
        {
            _productHelper = new Mock<IProductHelper>();
        }

        private void Setup()
        {

        }
    }
}
