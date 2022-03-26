using OrderService.Domain.Interfaces;
using OrderService.Domain.Services;
using OrderService.Infra.Data.Repository;
using OrderService.Services.API.Consumers;
using OrderService.Services.API.Services;

namespace OrderService.Services.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepositoryInMemory>();
            services.AddScoped<IOrderService, OrderServiceImpl>();
            services.AddScoped<IMessageSender, MessageSender>();

            services.AddHostedService<ProcessCreateOrderConsumer>();
        }
    }
}
