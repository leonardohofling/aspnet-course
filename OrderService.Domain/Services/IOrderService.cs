using OrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Services
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);

        void CancelOrder(String code);

        Order FindOrder(String code);
    }
}
