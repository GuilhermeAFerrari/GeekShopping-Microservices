using GeekShopping.MessageBus;

namespace GeekShopping.Payment.API.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
