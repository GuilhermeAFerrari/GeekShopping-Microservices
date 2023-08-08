using GeekShopping.Order.API.Messages;
using GeekShopping.Order.API.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.Order.API.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private IOrderRepository _orderRepository;
        private IConnection _connection;
        private IModel _channel;
        private const string EXCHANGE_NAME = "FanoutPaymentUpdateExchange";
        private readonly string _queueName = string.Empty;

        public RabbitMQPaymentConsumer(OrderRepository orderRepository)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _orderRepository = orderRepository;
            _channel.QueueBind(_queueName, EXCHANGE_NAME, "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                UpdatePaymentResultVO vo = JsonSerializer.Deserialize<UpdatePaymentResultVO>(content);
                UpdatePaymentStatus(vo).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(_queueName, false, consumer);
            return Task.CompletedTask;
        }

        private async Task UpdatePaymentStatus(UpdatePaymentResultVO vo)
        {
            try
            {
                await _orderRepository.UpdateOrderPaymentStatus(vo.OrderId, vo.Status);
            }
            catch (Exception)
            {
                // Log Exception
                throw;
            }
        }
    }
}
