using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.ToTable("Foods").HasKey(f => f.Id);
        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(f => f.Name).HasColumnName("Name").IsRequired();
        builder.Property(f => f.Description).HasColumnName("Description").IsRequired(false);
        builder.Property(f => f.ImageUrl).HasColumnName("ImageUrl").IsRequired(false);
        builder.Property(f => f.OriginalPrice).HasColumnName("OriginalPrice").IsRequired(false);
        builder.Property(f => f.DiscountedPrice).HasColumnName("DiscountedPrice").IsRequired(false);
        builder.Property(f => f.AvailableFrom).HasColumnName("AvailableFrom").IsRequired(false);
        builder.Property(f => f.AvailableUntil).HasColumnName("AvailableUntil").IsRequired(false);
        builder.Property(f => f.Stock).HasColumnName("Stock").IsRequired(false);
        builder.Property(f => f.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(f => f.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(f => f.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);

        builder.HasOne(f => f.Company)
               .WithMany(c => c.Foods)
               .HasForeignKey(f => f.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}