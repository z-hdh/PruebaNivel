using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Prueba.Services.RabbitMQ.Support;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Prueba.Services.RabbitMQ
{
    public class AmqpService
    {
        private readonly AmqpInfo amqpInfo;
        private readonly ConnectionFactory connectionFactory;

        public AmqpService(IOptions<AmqpInfo> ampOptionsSnapshot)
        {
            amqpInfo = ampOptionsSnapshot.Value;

            connectionFactory = new ConnectionFactory
            {
                UserName = amqpInfo.Username,
                Password = amqpInfo.Password,
                VirtualHost = amqpInfo.VirtualHost,
                HostName = amqpInfo.HostName,
                Uri = new Uri(amqpInfo.Uri)
            };
        }

        public void PublishMessage(string QueueName, object message)
        {
            using (var conn = connectionFactory.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: QueueName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var jsonPayload = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(jsonPayload);

                    channel.BasicPublish(exchange: "",
                        routingKey: QueueName,
                        basicProperties: null,
                        body: body
                    );
                }
            }
        }
    }
}
