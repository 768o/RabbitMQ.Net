using Rabbit.Net.Helper;
using RabbitMQ.Client;

namespace Rabbit.Net.Base
{
    public class MQConnection
    {
        public static readonly string Host = AppSetting.GetConfig("RabbitMQ:Host");
        public static readonly string UserName = AppSetting.GetConfig("RabbitMQ:UserName");
        public static readonly string Password = AppSetting.GetConfig("RabbitMQ:Password");
        public static ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = Host,
            UserName = UserName,
            Password = Password
        };
        public static IConnection connection = factory.CreateConnection();
        public static IModel channel = connection.CreateModel();

        public string QueueName { get; set; }
    }
}
