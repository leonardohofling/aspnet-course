using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Services
{
    public class OrderServiceImpl : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderServiceImpl(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public Order FindOrder(string code)
        {
            return orderRepository.GetByCode(code);
        }

        public Order CreateOrder(Order order)
        {
            ValidateCustomer(order);
            ValidateItems(order);

            order.Id = Guid.NewGuid();
            order.Code = string.Format("{0:yyyymmdd}_{1}", DateTime.Now, order.CustomerId);

            order.CreatedDate = DateTime.Now;
            order.UpdatedDate = DateTime.Now;

            order.Status = OrderStatus.Pending;

            order.Total = 0;

            foreach (var orderItem in order.Items)
            {
                var product = productRepository.GetProduct(orderItem.ProductId);

                if (product == null)
                    throw new Exception("Produto não encontrado.");

                orderItem.Id = Guid.NewGuid();
                orderItem.ProductName = product.Name;
                orderItem.UnitPrice = product.Price;
                orderItem.Total = orderItem.Quantity * orderItem.UnitPrice;

                order.Total += orderItem.Total;
            }

            orderRepository.Create(order);
            orderRepository.Commit();

            return order;
        }

        public void CancelOrder(string code)
        {
            var order = orderRepository.GetByCode(code);
            if (order == null)
                throw new Exception("Order not found");

            if (order.Status == OrderStatus.Canceled)
                throw new Exception("Order is already canceled");

            order.Status = OrderStatus.Canceled;
            order.CancelledDate = DateTime.Now;

            orderRepository.Update(order);
            orderRepository.Commit();
        }

        private void ValidateCustomer(Order order)
        {
            if (String.IsNullOrEmpty(order.CustomerId))
                throw new ArgumentException("Missing CustomerId", "CustomerId");
        }
        private void ValidateItems(Order order)
        {
            if (!order.Items.Any())
                throw new ArgumentException("Missing items", "Items");
        }
    }
}
