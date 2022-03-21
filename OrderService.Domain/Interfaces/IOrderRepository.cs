using OrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order GetByCode(String code);

        void Create(Order order);

        void Update(Order order);        

        void Delete(Order order);

        void Commit();
    }
}
