using bizYeriz.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizYeriz.Persistence.EntityConfigurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        // Tablo adı
        builder.ToTable("OrderItems");

        // Primary key
        builder.HasKey(oi => oi.Id);

        // Order ile ilişki
        builder
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade); 

        // Food ile ilişki
        builder
            .HasOne(oi => oi.Food)
            .WithMany(f => f.OrderItems)             
            .HasForeignKey(oi => oi.FoodId)
            .OnDelete(DeleteBehavior.Cascade);

        // Property configurations
        builder.Property(oi => oi.FoodName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(oi => oi.FoodImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(oi => oi.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(oi => oi.TotalPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(oi => oi.Quantity)
            .IsRequired();

    }
}