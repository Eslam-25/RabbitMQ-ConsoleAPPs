using RabbitMQ.Client;
using RabbitMQ.Producer;
using System;

namespace Service1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello I'm Producer"); 
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            while (true) 
            {
                Console.Write("Enter consumer type (bank/chat): ");
                string consumerType = Console.ReadLine();
                Console.Write("Enter message to sent: ");
                string message = Console.ReadLine();
                QueueProducer.Publish(channel, consumerType, message);
            }
        }
    }
}
