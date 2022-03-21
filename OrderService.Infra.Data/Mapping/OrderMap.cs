using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infra.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(prop => prop.Id)
                .HasColumnName("Id");

            builder.Property(prop => prop.CustomerId)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(prop => prop.Code)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(prop => prop.CreatedDate)
                .IsRequired();

            builder.Property(prop => prop.UpdatedDate)
                .IsRequired();

            builder.Property(prop => prop.Status)
                .IsRequired();

            builder.Property(prop => prop.Total)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.HasMany(prop => prop.Items)
                .WithOne()
                .HasForeignKey(prop => prop.OrderId);
        }
    }
}
