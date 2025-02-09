using bizYeriz.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");
        builder.HasKey(oi => oi.Id);
        builder.Property(oi => oi.FoodName).IsRequired();
        builder.Property(oi => oi.FoodImageUrl).IsRequired();
        builder.Property(oi => oi.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(oi => oi.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(oi => oi.Quantity).IsRequired();

        builder
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(oi => oi.Food)
            .WithMany(f => f.OrderItems)
            .HasForeignKey(oi => oi.FoodId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}