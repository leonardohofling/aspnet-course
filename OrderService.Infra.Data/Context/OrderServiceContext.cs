using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Models;
using OrderService.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infra.Data.Context
{
    public class OrderServiceContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderServiceContext(DbContextOptions<OrderServiceContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
