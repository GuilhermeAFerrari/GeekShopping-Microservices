using GeekShopping.Cart.API.Messages;
using GeekShopping.MessageBus;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace GeekShopping.Cart.API.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly IConfiguration _configuration;
        private IConnection _connection;

        public RabbitMQMessageSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage(BaseMessage message, string queueName)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _configuration["RabbitMQ:HostName"],
                    UserName = _configuration["RabbitMQ:UserName"],
                    Password = _configuration["RabbitMQ:Password"]
                };
                _connection = factory.CreateConnection();

                using var channel = _connection.CreateModel();
                channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
                byte[] body = GetMessageAsByteArray(message);
                channel.BasicPublish(
                    exchange: "", routingKey: queueName, basicProperties: null, body: body);
            }
            catch (Exception ex)
            {

                throw;

            }
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize((CheckoutHeaderVO)message, options);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
