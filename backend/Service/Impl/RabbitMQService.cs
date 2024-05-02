using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace backend
{
    public class RabbitMQService : IRabbitMQService
    {
        public void ReceiveMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare("request-queue", exclusive: false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                Console.WriteLine($"Received Request: {ea.BasicProperties.CorrelationId}");
                var stringReply = ea.BasicProperties.CorrelationId + "hihihihi";
                var replyMessage = $"This is your reply: {stringReply}";

                var body = Encoding.UTF8.GetBytes(replyMessage);

                channel.BasicPublish("", ea.BasicProperties.ReplyTo, null, body);
            };

            channel.BasicConsume(queue: "request-queue", autoAck: true, consumer: consumer);
        }
    }
}
