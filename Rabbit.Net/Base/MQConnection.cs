using Rabbit.Net.Helper;
using RabbitMQ.Client;

namespace Rabbit.Net.Base
{
    public class MQConnection
    {
        public static readonly string Host = AppSetting.GetConfig("RabbitMQ:Host");
        public static ConnectionFactory factory = new ConnectionFactory() { HostName = Host };
        public static IConnection connection = factory.CreateConnection();
        public static IModel channel = connection.CreateModel();

        public string QueueName { get; set; }
    }
}
