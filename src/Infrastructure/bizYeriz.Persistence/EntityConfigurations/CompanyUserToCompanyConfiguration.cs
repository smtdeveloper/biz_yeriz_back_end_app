using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class CompanyUserToCompanyConfiguration : IEntityTypeConfiguration<CompanyUserToCompany>
{
    public void Configure(EntityTypeBuilder<CompanyUserToCompany> builder)
    {
        // Tablo adını belirleme
        builder.ToTable("CompanyUserToCompany");

        // Birincil anahtar tanımlama (Bileşik Anahtar)
        builder.HasKey(cutc => new { cutc.CompanyUserId, cutc.CompanyId });

        // İlişkiler
        builder
            .HasOne(cutc => cutc.CompanyUser) // CompanyUser ile ilişki
            .WithMany(cu => cu.CompanyUserToCompanies) // CompanyUser'ın birçok CompanyUserToCompany kaydı olabilir
            .HasForeignKey(cutc => cutc.CompanyUserId) // Yabancı anahtar
            .OnDelete(DeleteBehavior.Restrict); // Silme davranışı

        builder
            .HasOne(cutc => cutc.Company) // Company ile ilişki
            .WithMany(c => c.CompanyUserToCompanies) // Company'nin birçok CompanyUserToCompany kaydı olabilir
            .HasForeignKey(cutc => cutc.CompanyId) // Yabancı anahtar
            .OnDelete(DeleteBehavior.Restrict); // Silme davranışı

        // Alan özelliklerini tanımlama
        builder.Property(cutc => cutc.CreatedDate)
            .IsRequired(); // Zorunlu alan            
    }
}