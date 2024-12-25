using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Tablo adı
        builder.ToTable("Orders");

        // Primary key
        builder.HasKey(o => o.Id);

        // CompanyComment ile bire bir ilişki
        builder
            .HasOne(o => o.CompanyComment)
            .WithOne(c => c.Order)
            .HasForeignKey<CompanyComment>(c => c.OrderId); // CompanyComment entity'si bağımlı taraf

        // User ile ilişki
        builder
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        // Company ile ilişki
        builder
            .HasOne(o => o.Company)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CompanyId);

        // OrderItems ile ilişki (One-to-many ilişki)
        builder
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // Ensures that when an Order is deleted, its related OrderItems are also deleted

        // Property configurations
        builder.Property(o => o.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.TaxAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.Discount)
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.ShippingCost)
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.RefundAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.PaymentMethod)
            .IsRequired();            

        builder.Property(o => o.DeliveryType)
            .IsRequired();

        builder.Property(o => o.Notes);           

        builder.Property(o => o.TrackingNumber);            

        builder.Property(o => o.CouponCode);            
    }
}