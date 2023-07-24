using GeekShopping.MessageBus;

namespace GeekShopping.Cart.API.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
