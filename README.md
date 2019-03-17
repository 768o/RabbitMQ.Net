# RabbitMQ.Net
基于RabbitMQ的简易版消息队列框架，即开即用，容易上手。

## 首先你得安装RabbitMQ
#### 1.安装erlang。（使用管理员运行）http://www.erlang.org/downloads
#### 2.安装rabbitMQ。http://www.rabbitmq.com/install-windows.html

### 如何应用于你的项目中
#### 1.在你的项目中引入RabbitMQ.Net.dll
#### 2.在你的配置文件appsetting.json()中添加配置信息

```
"RabbitMQ": {
  "Host": "localhost",
    "QueueNames": {
      "Test": "Test"
  }
}
```
#### 3.完成你的消息生产者（这个类并非是必须的，但推荐你这样做）
```
public class TestProducer : ProducerBase{
  public TestProducer() : base(QueueNamesConst.Test){

  }
}
```
#### 4.完成你的消息消费者（你只需要写Todo方法）
```
public class TestConsumer : ConsumerBase{
   public TestConsumer() : base(QueueNamesConst.Test){
      CreateConsumer(Todo);
   }
   private void Todo(string message){
      var dto = message.ToObject<TestDto>();//TestDto为你的数据传输类
      //业务逻辑
   }
}
```
#### 5.调用他们
```
for (var i = 0; i < 10; i++)
{
   new TestProducer().CreateMessage(new TestDto());//10条信息入队列
   //new ProducerBase(QueueNamesConst.Test).CreateMessage(new TestDto());//当你没有写专门的生产者类时，10条信息入队列
}
new TestConsumer();//创建一个消息消费者，请不要关闭程序（在另一个系统中，如果你把他们放在一起，那毫无意义）
```
