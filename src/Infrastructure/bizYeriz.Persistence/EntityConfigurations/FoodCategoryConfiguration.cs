using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class FoodCategoryConfiguration : IEntityTypeConfiguration<FoodCategory>
{
    public void Configure(EntityTypeBuilder<FoodCategory> builder)
    {
        // Tablo adı ve birincil anahtar
        builder.ToTable("FoodCategories").HasKey(fc => fc.Id);

        // Alan isimleri ve zorunluluklar
        builder.Property(fc => fc.Id).HasColumnName("Id").IsRequired();
        builder.Property(fc => fc.Name).HasColumnName("Name").IsRequired().HasMaxLength(100); // Maksimum uzunluk belirledim
        builder.Property(fc => fc.Description).HasColumnName("Description").IsRequired().HasMaxLength(500); // Maksimum uzunluk belirledim
        builder.Property(fc => fc.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(fc => fc.OrderNumber).HasColumnName("OrderNumber").IsRequired();
        builder.Property(fc => fc.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(fc => fc.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(fc => fc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fc => fc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fc => fc.DeletedDate).HasColumnName("DeletedDate");

        // İlişkiler
        builder.HasMany(fc => fc.FoodCategoryAndFoods) // FoodCategory'ın birçok FoodCategoryAndFood'u olabilir
            .WithOne(fcaf => fcaf.FoodCategory) // FoodCategoryAndFood'un her bir kaydı, bir FoodCategory ile ilişkilendirilir
            .HasForeignKey(fcaf => fcaf.FoodCategoryId); // Yabancı anahtar (FoodCategoryId)
    }
}