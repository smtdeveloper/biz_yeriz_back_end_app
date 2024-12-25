using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class FavoriteCompanyConfiguration : IEntityTypeConfiguration<FavoriteCompany>
{
    public void Configure(EntityTypeBuilder<FavoriteCompany> builder)
    {
        // Tablo adı ve birincil anahtar tanımı
        builder.ToTable("FavoriteCompanies");
        builder.HasKey(fc => fc.Id);

        // Id için otomatik artan yapılandırma
        builder.Property(fc => fc.Id)
               .ValueGeneratedOnAdd();

        // CustomerId için yabancı anahtar ilişkisi
        builder.Property(fc => fc.UserId)
               .IsRequired();
        builder.HasOne(fc => fc.User)
               .WithMany(c => c.FavoriteCompany)
               .HasForeignKey(fc => fc.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // CompanyId için yabancı anahtar ilişkisi
        builder.Property(fc => fc.CompanyId)
               .IsRequired();
        builder.HasOne(fc => fc.Company)
               .WithMany()
               .HasForeignKey(fc => fc.CompanyId)
               .OnDelete(DeleteBehavior.Cascade);

        // Tablonun ortak alanlarının yapılandırılması
        builder.Property(fc => fc.CreatedDate)
               .HasColumnName("CreatedDate")
               .IsRequired();

        builder.Property(fc => fc.UpdatedDate)
               .HasColumnName("UpdatedDate");

        builder.Property(fc => fc.DeletedDate)
               .HasColumnName("DeletedDate");

    }
}
