using Rabbit.Net.Base;
using Rabbit.Net.Consumer;
using Rabbit.Net.Helper;
using Rabbit.Net.Service.Test.Dto;

namespace Rabbit.Net.Service.Test
{
    public class TestConsumer : ConsumerBase
    {
        public TestConsumer() : base(QueueNamesConst.Test)
        {
            CreateConsumer(Todo);
        }

        private void Todo(string message)
        {
            var dto = message.ToObject<TestDto>();

            //业务逻辑
        }
    }
}
