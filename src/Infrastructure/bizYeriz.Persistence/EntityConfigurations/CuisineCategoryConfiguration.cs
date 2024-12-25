using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class CuisineCategoryConfiguration : IEntityTypeConfiguration<CuisineCategory>
{
    public void Configure(EntityTypeBuilder<CuisineCategory> builder)
    {
        // Table name and primary key
        builder.ToTable("CuisineCategories");
        builder.HasKey(kc => kc.Id);

        // Properties
        builder.Property(kc => kc.Id)
               .HasColumnName("Id")
               .IsRequired();

        builder.Property(kc => kc.CategoryName)
               .HasColumnName("CategoryName")
               .IsRequired()
               .HasMaxLength(100); // Assuming a max length constraint

        builder.Property(kc => kc.ImageUrl)
               .HasColumnName("ImageUrl")
               .HasMaxLength(255); // Assuming a max length constraint for URLs

        builder.Property(kc => kc.IsActive)
               .HasColumnName("IsActive")
               .IsRequired();

        builder.Property(kc => kc.IsDelete)
               .HasColumnName("IsDelete")
               .IsRequired();

        builder.Property(kc => kc.CreatedDate)
               .HasColumnName("CreatedDate")
               .IsRequired();

        builder.Property(kc => kc.UpdatedDate)
               .HasColumnName("UpdatedDate")
               .IsRequired(false); // Optional field

        builder.Property(kc => kc.DeletedDate)
               .HasColumnName("DeletedDate")
               .IsRequired(false); // Optional field

        // Relationships
        builder.HasMany(kc => kc.CuisineCategoryAndFoods)
               .WithOne(ccf => ccf.CuisineCategory)
               .HasForeignKey(ccf => ccf.CuisineCategoryId)
               .OnDelete(DeleteBehavior.Restrict); // Assuming restrict behavior for delete
    }
}