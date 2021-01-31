using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace RabbitMQ.Producer
{
    public static class QueueProducer
    {
        public static void Publish(IModel channel,string consumerType, string message)
        {
            channel.QueueDeclare($"queue-{consumerType}",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            var messageBody = new { Name = "Producer", Message = message };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messageBody));
            channel.BasicPublish("", $"queue-{consumerType}", null, body);
            Thread.Sleep(1000);
        }
    }
}
