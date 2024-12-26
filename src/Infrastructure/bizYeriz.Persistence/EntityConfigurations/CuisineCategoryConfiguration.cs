using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class CuisineCategoryConfiguration : IEntityTypeConfiguration<CuisineCategory>
{
    public void Configure(EntityTypeBuilder<CuisineCategory> builder)
    {       
        builder.ToTable("CuisineCategories");
        builder.HasKey(kc => kc.Id);
        builder.Property(kc => kc.Id).HasColumnName("Id").IsRequired();
        builder.Property(kc => kc.CategoryName).HasColumnName("CategoryName").IsRequired();
        builder.Property(kc => kc.ImageUrl).HasColumnName("ImageUrl").IsRequired(false);
        builder.Property(kc => kc.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(kc => kc.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(kc => kc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(kc => kc.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(kc => kc.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);
    }
}