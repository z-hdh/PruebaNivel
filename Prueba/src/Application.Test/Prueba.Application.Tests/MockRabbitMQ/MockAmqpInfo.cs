using Microsoft.Extensions.Options;
using Moq;

namespace Prueba.Application.Unit.Tests.MockRabbitMQ
{
    class MockAmqpInfo
    {
        public Mock<IOptions<MockAmqpInfo>> _amqpInfo { get; set; }

        public MockAmqpInfo()
        {
            _amqpInfo = new Mock<IOptions<MockAmqpInfo>>();
        }

        private void Setup()
        {

        }
    }
}
