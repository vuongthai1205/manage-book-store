using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitListener
{
    ConnectionFactory Factory { get; set; }
    IConnection Connection { get; set; }
    IModel Channel { get; set; }

    public void Register()
    {
        Channel.QueueDeclare("request-queue", exclusive: false);

        var consumer = new EventingBasicConsumer(Channel);

        consumer.Received += (model, ea) =>
        {
            Console.WriteLine($"Received Request: {ea.BasicProperties.CorrelationId}");
            var stringReply = ea.BasicProperties.CorrelationId + "hihihihi";
            var replyMessage = $"This is your reply: {stringReply}";

            var body = Encoding.UTF8.GetBytes(replyMessage);

            Channel.BasicPublish("", "reply-queue", null, body);
        };

        Channel.BasicConsume(queue: "request-queue", autoAck: true, consumer: consumer);
    }

    public void Deregister()
    {
        this.Connection.Close();
    }

    public RabbitListener()
    {
        this.Factory = new ConnectionFactory() { HostName = "localhost" };
        this.Connection = Factory.CreateConnection();
        this.Channel = Connection.CreateModel();


    }
}