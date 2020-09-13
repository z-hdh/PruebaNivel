using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ConsoleClient
{
    class Program
    {
            static void Main(string[] args)
            {
                var factory = new ConnectionFactory()
                {
                    UserName = "xuejcrwx",
                    Password = "1DMdq3rWX6tiVSgM7gfYfHba1bgvOTpf",
                    VirtualHost = "xuejcrwx",
                    HostName = "xuejcrwx",
                    Uri = new Uri("amqps://xuejcrwx:1DMdq3rWX6tiVSgM7gfYfHba1bgvOTpf@chinook.rmq.cloudamqp.com/xuejcrwx")
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "RemoveItem",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume(queue: "RemoveItem",
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
}
