﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace ConsoleClientRemoveItem
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

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, ea) =>
                {
                    var body = ea.Body.ToArray();

                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine(" [x] Received {0}", message);

                    int dots = message.Split('.').Length - 1;

                    Thread.Sleep(dots * 1000);

                    Console.WriteLine(" [x] Done");

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                channel.BasicConsume(queue: "RemoveItem",
                                     autoAck: false,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");

                Console.ReadLine();
            }
        }
    }
}
