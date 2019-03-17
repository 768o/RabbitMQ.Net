using Rabbit.Net.Service.Test;
using Rabbit.Net.Service.Test.Dto;
using System;

namespace Rabbit.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                new TestProducer().CreateMessage(new TestDto());//10条信息入队列
            }

            new TestConsumer();//创建一个消息消费者

            Console.ReadLine();
        }
    }
}
