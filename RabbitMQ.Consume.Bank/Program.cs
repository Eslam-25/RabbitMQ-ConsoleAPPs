using RabbitMQ.Client;
using RabbitMQ.Consumer;
using System;

namespace RabbitMQ.Consume.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello I'm Bank Consumer");
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            QueueConsumer.Consume(channel);
        }
    }
}
