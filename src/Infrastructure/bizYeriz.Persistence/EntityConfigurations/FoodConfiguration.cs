using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace bizYeriz.Persistence.EntityConfigurations;
public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.ToTable("Foods").HasKey(f => f.Id);        
        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(f => f.Name).HasColumnName("Name").IsRequired();
        builder.Property(f => f.Description).HasColumnName("Description");
        builder.Property(f => f.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(f => f.OrjinalPrice).HasColumnName("OrjinalPrice");
        builder.Property(f => f.DiscountedPrice).HasColumnName("DiscountedPrice").IsRequired();
        builder.Property(f => f.AvailableFrom).HasColumnName("AvailableFrom");
        builder.Property(f => f.AvailableUntil).HasColumnName("AvailableUntil");
        builder.Property(f => f.Stock).HasColumnName("Stock");

        builder.Property(f => f.IsActive).HasColumnName("IsActive");
        builder.Property(f => f.IsDelete).HasColumnName("IsDelete");

        builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(f => f.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(f => f.FoodCategoryAndFoods);
        builder.HasOne(f => f.Company);

        builder.HasQueryFilter(f => !f.DeletedDate.HasValue);
    }
}
