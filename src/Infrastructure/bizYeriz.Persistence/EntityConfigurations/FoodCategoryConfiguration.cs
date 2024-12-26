using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class FoodCategoryConfiguration : IEntityTypeConfiguration<FoodCategory>
{
    public void Configure(EntityTypeBuilder<FoodCategory> builder)
    {
        builder.ToTable("FoodCategories").HasKey(fc => fc.Id);
        builder.Property(fc => fc.Id).HasColumnName("Id").IsRequired();
        builder.Property(fc => fc.Name).HasColumnName("Name").IsRequired(); 
        builder.Property(fc => fc.Description).HasColumnName("Description").IsRequired();
        builder.Property(fc => fc.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(fc => fc.OrderNumber).HasColumnName("OrderNumber").IsRequired();
        builder.Property(fc => fc.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(fc => fc.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(fc => fc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fc => fc.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(fc => fc.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);
    }
}