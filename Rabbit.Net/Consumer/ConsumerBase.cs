using Rabbit.Net.Base;
using Rabbit.Net.Helper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Rabbit.Net.Consumer
{
    public class ConsumerBase : MQConnection
    {
        public delegate void Job(string message);

        public ConsumerBase(string queueName)
        {
            QueueName = queueName;
        }

        /// <summary>
        /// 使用默认配置，创建一个消息消费者
        /// </summary>
        /// <param name="job"></param>
        public void CreateConsumer(Job job)
        {
            channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicQos(0, 1, false);//公平派遣，在一个消费者没有确认消息完成时，不要给他发新消息
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Logger.Log.Info("Consumer:" + message);
                job(message);
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);//手动消息确认
            };
            channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);
        }
    }
}
