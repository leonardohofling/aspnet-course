using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Models;

namespace OrderService.Infra.Data.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(prop => prop.Id)
                .HasColumnName("Id");

            builder.Property(prop => prop.ProductId)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.ProductName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.Quantity)
                .IsRequired();

            builder.Property(prop => prop.UnitPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(prop => prop.Total)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}