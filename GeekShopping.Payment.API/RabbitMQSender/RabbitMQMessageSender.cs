using GeekShopping.MessageBus;
using GeekShopping.Payment.API.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GeekShopping.Payment.API.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly IConfiguration _configuration;
        private IConnection _connection;
        private const string EXCHANGE_NAME = "FanoutPaymentUpdateExchange";

        public RabbitMQMessageSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage(BaseMessage message)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();
                channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Fanout, durable: false);
                byte[] body = GetMessageAsByteArray(message);
                channel.BasicPublish(
                    exchange: EXCHANGE_NAME, "", basicProperties: null, body: body);
            }
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize((UpdatePaymentResultMessage)message, options);
            return Encoding.UTF8.GetBytes(json);
        }

        private void CreateConnection()
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
            }
            catch (Exception)
            {
                // Log Exception
                throw;
            }
        }

        private bool ConnectionExists()
        {
            if (_connection is not null) return true;

            CreateConnection();
            return _connection != null;
        }
    }
}
