using OrderService.Domain.Interfaces;
using OrderService.Domain.Services;
using OrderService.Infra.Data.Repository;

namespace OrderService.Services.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderServiceImpl>();
        }
    }
}
