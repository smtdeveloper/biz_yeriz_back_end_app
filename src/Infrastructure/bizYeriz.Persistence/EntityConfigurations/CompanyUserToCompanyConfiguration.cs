using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class CompanyUserToCompanyConfiguration : IEntityTypeConfiguration<CompanyUserToCompany>
{
    public void Configure(EntityTypeBuilder<CompanyUserToCompany> builder)
    {
        builder.ToTable("CompanyUserToCompany");
        builder.HasKey(cutc => new { cutc.CompanyUserId, cutc.CompanyId });
        builder.Property(cutc => cutc.CreatedDate).IsRequired();

        builder
            .HasOne(cutc => cutc.CompanyUser)
            .WithMany(cu => cu.CompanyUserToCompanies)
            .HasForeignKey(cutc => cutc.CompanyUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(cutc => cutc.Company)
            .WithMany(c => c.CompanyUserToCompanies)
            .HasForeignKey(cutc => cutc.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}