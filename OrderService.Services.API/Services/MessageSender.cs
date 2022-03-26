using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OrderService.Services.API.Configuration;
using OrderService.Services.API.Models;
using RabbitMQ.Client;
using System.Text;

namespace OrderService.Services.API.Services
{
    public class MessageSender : IMessageSender
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _createOrdersQueueName;

        public MessageSender(IOptions<RabbitMQConfig> options)
        {
            _createOrdersQueueName = options.Value.CreateOrdersQueueName;

            _connectionFactory = new ConnectionFactory
            {
                HostName = options.Value.HostName,
                Port = options.Value.Port,
                UserName = options.Value.UserName,
                Password = options.Value.Password,
                VirtualHost = options.Value.VirtualHost
            };

            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declarar a fila
            _channel.QueueDeclare(_createOrdersQueueName, true, false, false, null);
        }

        public void PublishOrder(CreateOrderViewModel orderViewModel)
        {
            var messageBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(orderViewModel));
            _channel.BasicPublish("", _createOrdersQueueName, false, null, messageBytes);
        }
    }
}
