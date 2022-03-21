using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public string CustomerId { get; set; }

        public string Code { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime? CancelledDate { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItem> Items { get; set; }

        public decimal Total { get; set; }
    }
}
