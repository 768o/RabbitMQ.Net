using Rabbit.Net.Base;
using Rabbit.Net.Helper;
using RabbitMQ.Client;
using System.Text;

namespace Rabbit.Net.Producer
{
    public class ProducerBase : MQConnection
    {
        public ProducerBase(string queueName)
        {
            QueueName = queueName;
        }

        public void CreateMessage<T>(T t)
        {
            CreateMessage(t.ToJsonString());
        }

        public void CreateMessage(string message)
        {
            channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            Logger.Log.Info("Producer:" + message);
            channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);
        }
    }
}
