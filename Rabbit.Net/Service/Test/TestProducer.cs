using Rabbit.Net.Base;
using Rabbit.Net.Producer;
using Rabbit.Net.Service.Test.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbit.Net.Service.Test
{
    public class TestProducer : ProducerBase
    {
        public TestProducer() : base(QueueNamesConst.Test)
        {

        }
    }
}
