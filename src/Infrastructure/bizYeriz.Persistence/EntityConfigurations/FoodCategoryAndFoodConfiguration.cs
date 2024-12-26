using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class FoodCategoryAndFoodConfiguration : IEntityTypeConfiguration<FoodCategoryAndFood>
{
    public void Configure(EntityTypeBuilder<FoodCategoryAndFood> builder)
    {
        builder.ToTable("FoodCategoryAndFoods").HasKey(fcf => fcf.Id);
        builder.Property(fcf => fcf.Id).HasColumnName("Id").IsRequired();
        builder.Property(fcf => fcf.FoodCategoryId).HasColumnName("FoodCategoryId").IsRequired();
        builder.Property(fcf => fcf.FoodId).HasColumnName("FoodId").IsRequired();
        builder.Property(ff => ff.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ff => ff.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(ff => ff.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);

        builder.HasOne(fcf => fcf.Food)
               .WithMany(f => f.FoodCategoryAndFoods)
               .HasForeignKey(fcf => fcf.FoodId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(fcf => fcf.FoodCategory)
               .WithMany(fc => fc.FoodCategoryAndFoods)
               .HasForeignKey(fcf => fcf.FoodCategoryId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}