using GeekShopping.MessageBus;

namespace GeekShopping.Order.API.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
