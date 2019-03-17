using Rabbit.Net.Helper;

namespace Rabbit.Net.Base
{
    public class QueueNamesConst
    {
        public static readonly string Test = AppSetting.GetConfig("RabbitMQ:QueueNames:Test");
    }
}
