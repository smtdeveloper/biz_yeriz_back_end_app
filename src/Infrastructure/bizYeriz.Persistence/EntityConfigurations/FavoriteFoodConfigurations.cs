using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class FavoriteFoodConfigurations : IEntityTypeConfiguration<FavoriteFood>
{
    public void Configure(EntityTypeBuilder<FavoriteFood> builder)
    {
        // Tablo adı ve birincil anahtar tanımı
        builder.ToTable("FavoriteFoods");
        builder.HasKey(ff => ff.Id);

        // Id için otomatik artan yapılandırma
        builder.Property(ff => ff.Id)
               .ValueGeneratedOnAdd();

        // CustomerId için yabancı anahtar ilişkisi
        builder.Property(ff => ff.UserId)
               .IsRequired();
        builder.HasOne(ff => ff.User)
               .WithMany(c => c.FavoriteFood)
               .HasForeignKey(ff => ff.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // FoodId için yabancı anahtar ilişkisi
        builder.Property(ff => ff.FoodId)
               .IsRequired();

        builder.HasOne(ff => ff.Food)
               .WithMany()
               .HasForeignKey(ff => ff.FoodId)
               .OnDelete(DeleteBehavior.Cascade);

        // Tablonun ortak alanlarının yapılandırılması
        builder.Property(ff => ff.CreatedDate)
               .HasColumnName("CreatedDate")
               .IsRequired();

        builder.Property(ff => ff.UpdatedDate)
               .HasColumnName("UpdatedDate");

        builder.Property(ff => ff.DeletedDate)
               .HasColumnName("DeletedDate");

    }
}