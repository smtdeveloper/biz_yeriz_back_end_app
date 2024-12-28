using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(o => o.TaxAmount).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(o => o.Discount).HasColumnType("decimal(18,2)").IsRequired(false);
        builder.Property(o => o.ShippingCost).HasColumnType("decimal(18,2)").IsRequired(false);
        builder.Property(o => o.RefundAmount).HasColumnType("decimal(18,2)").IsRequired(false);
        builder.Property(o => o.PaymentMethod).IsRequired().IsRequired(false);
        builder.Property(o => o.DeliveryType).IsRequired().IsRequired();
        builder.Property(o => o.Notes).IsRequired(false);
        builder.Property(o => o.TrackingNumber).IsRequired(false);
        builder.Property(o => o.CouponCode).IsRequired(false);

        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(o => o.Company)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.CompanyComment)
            .WithOne(c => c.Order)
            .HasForeignKey<CompanyComment>(c => c.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}