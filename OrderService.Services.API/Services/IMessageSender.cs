using OrderService.Services.API.Models;

namespace OrderService.Services.API.Services
{
    public interface IMessageSender
    {
        void PublishOrder(CreateOrderViewModel orderViewModel);
    }
}