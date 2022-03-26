using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OrderService.Domain.Models;
using OrderService.Domain.Services;
using OrderService.Services.API.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace OrderService.Services.API.Consumers
{
    public class ProcessCreateOrderConsumer : BackgroundService
    {
        private readonly string _createOrdersQueueName;
        private readonly IServiceProvider _serviceProvider;
        private readonly ConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        private readonly IMapper _mapper;
        private readonly ILogger<ProcessCreateOrderConsumer> _logger;

        public ProcessCreateOrderConsumer(IOptions<RabbitMQConfig> options, IServiceProvider serviceProvider, IMapper mapper, 
            ILogger<ProcessCreateOrderConsumer> logger)
        {
            _createOrdersQueueName = options.Value.CreateOrdersQueueName;
            _serviceProvider = serviceProvider;
            _mapper = mapper;
            _logger = logger;

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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += Consumer_Received;

            _channel.BasicConsume(_createOrdersQueueName, false, consumer);

            return Task.CompletedTask;
        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs eventArgs)
        {
            _logger.LogInformation($"Mensagem recebida {DateTime.Now}");

            var message = JsonConvert.DeserializeObject<Models.CreateOrderViewModel>(
                Encoding.UTF8.GetString(eventArgs.Body.ToArray()));

            using (var scope = _serviceProvider.CreateScope())
            {
                var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                var order = orderService.CreateOrder(_mapper.Map<Order>(message));
                
                _logger.LogInformation($"Pedido {order.Code} criado com sucesso!");
            }            

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        }
    }
}
