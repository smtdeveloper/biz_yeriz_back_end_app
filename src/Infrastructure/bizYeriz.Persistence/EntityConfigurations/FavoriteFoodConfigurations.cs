using bizYeriz.Domain.Entities.FoodEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class FavoriteFoodConfigurations : IEntityTypeConfiguration<FavoriteFood>
{
    public void Configure(EntityTypeBuilder<FavoriteFood> builder)
    {        
        builder.ToTable("FavoriteFoods");
        builder.HasKey(ff => ff.Id);
        builder.Property(ff => ff.UserId).IsRequired();
        builder.Property(ff => ff.FoodId).IsRequired();
        builder.Property(ff => ff.Id).ValueGeneratedOnAdd();
        builder.Property(ff => ff.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ff => ff.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(ff => ff.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);

        builder.HasOne(ff => ff.User)
               .WithMany(c => c.FavoriteFood)
               .HasForeignKey(ff => ff.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ff => ff.Food)
               .WithMany(f => f.FavoriteFood)
               .HasForeignKey(ff => ff.FoodId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}