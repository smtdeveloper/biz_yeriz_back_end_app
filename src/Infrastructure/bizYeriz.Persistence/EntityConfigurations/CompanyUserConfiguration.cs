using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;
public class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
{
    public void Configure(EntityTypeBuilder<CompanyUser> builder)
    {
        // Tablo adını belirleme (Opsiyonel)
        builder.ToTable("CompanyUsers");

        // Birincil Anahtar (Varsayılan olarak BaseEntity ile gelen ID alanı kullanılır)
        builder.HasKey(cu => cu.Id);

        // İlişkiler
        builder
            .HasOne(cu => cu.User) // CompanyUser ile User ilişkisi
            .WithOne(u => u.CompanyUser) // Bir User'ın bir CompanyUser ile ilişkisi
            .HasForeignKey<CompanyUser>(cu => cu.UserId) // CompanyUser'da UserId yabancı anahtar olarak kullanılır
            .OnDelete(DeleteBehavior.Restrict); // Silme davranışı, User silinemezse CompanyUser silinir

        builder
            .HasMany(cu => cu.CompanyUserToCompanies) // CompanyUser'ın birçok CompanyUserToCompany kaydı olabilir
            .WithOne(cutc => cutc.CompanyUser) // CompanyUserToCompany'nın CompanyUser ile ilişkilendirilmesi
            .HasForeignKey(cutc => cutc.CompanyUserId); // Yabancı anahtar (CompanyUserId)

        // Alan özelliklerini tanımlama (isteğe bağlı)
        builder.Property(cu => cu.Position)
            .HasMaxLength(200); // Position alanı için maksimum uzunluk 200 karakter olarak belirlendi

        // Zorunlu alanlar, default değerler vb. eklemek
        builder.Property(cu => cu.UserId)
            .IsRequired(); // UserId zorunlu alan olarak belirlendi
    }
}