using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;
public class CuisineCategoryAndFoodConfiguration : IEntityTypeConfiguration<CuisineCategoryAndFood>
{
    public void Configure(EntityTypeBuilder<CuisineCategoryAndFood> builder)
    {
        builder.ToTable("CuisineCategoryAndFoods");
        builder.HasKey(ccf => ccf.Id);
        builder.Property(ccf => ccf.Id).HasColumnName("Id").IsRequired();
        builder.Property(ccf => ccf.CuisineCategoryId).HasColumnName("CuisineCategoryId").IsRequired();
        builder.Property(ccf => ccf.FoodId).HasColumnName("FoodId").IsRequired();
        builder.Property(ccf => ccf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ccf => ccf.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(ccf => ccf.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);

        builder.HasOne(ccf => ccf.CuisineCategory)
               .WithMany(cc => cc.CuisineCategoryAndFoods)
               .HasForeignKey(ccf => ccf.CuisineCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ccf => ccf.Food)
               .WithMany(f => f.CuisineCategoryAndFoods)
               .HasForeignKey(ccf => ccf.FoodId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}