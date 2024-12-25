using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class FoodCategoryAndFoodConfiguration : IEntityTypeConfiguration<FoodCategoryAndFood>
{
    public void Configure(EntityTypeBuilder<FoodCategoryAndFood> builder)
    {
        // Tablo adı ve birincil anahtar
        builder.ToTable("FoodCategoryAndFoods").HasKey(fcf => fcf.Id);

        // Alanlar
        builder.Property(fcf => fcf.Id).HasColumnName("Id").IsRequired();
        builder.Property(fcf => fcf.FoodCategoryId).HasColumnName("FoodCategoryId").IsRequired();
        builder.Property(fcf => fcf.FoodId).HasColumnName("FoodId").IsRequired();

        // İlişkiler
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