using Moq;
using Prueba.Services.RabbitMQ;

namespace Prueba.Application.Unit.Tests.MockRabbitMQ
{
    public class MockAmqpService
    {
        public Mock<AmqpService> _amqpService { get; set; }

        public MockAmqpService()
        {
            _amqpService = new Mock<AmqpService>();
        }

        private void Setup()
        {

        }
    }
}
