using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using OrderService.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderServiceContext orderServiceContext;

        public OrderRepository(OrderServiceContext orderServiceContext)
        {
            this.orderServiceContext = orderServiceContext;
        }                

        public Order GetByCode(string code)
        {
            return orderServiceContext.Orders.FirstOrDefault(order => order.Code.Equals(code));
        }

        public void Create(Order order)
        {
            orderServiceContext.Orders.Add(order);
        }

        public void Update(Order order)
        {
            orderServiceContext.Update(order);
        }

        public void Delete(Order order)
        {
            orderServiceContext.Orders.Remove(order);
        }        

        public void Commit()
        {
            orderServiceContext.SaveChanges();
        }
    }
}
