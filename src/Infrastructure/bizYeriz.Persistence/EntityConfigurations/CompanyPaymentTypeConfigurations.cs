using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace bizYeriz.Persistence.EntityConfigurations;

public class CompanyPaymentTypeConfigurations : IEntityTypeConfiguration<CompanyPaymentType>
{
    public void Configure(EntityTypeBuilder<CompanyPaymentType> builder)
    {
        builder.ToTable("CompanyPaymentType").HasKey(_companyPaymentType => new { _companyPaymentType.CompanyId, _companyPaymentType.PaymentTypeId });

        builder
            .HasOne(cpt => cpt.Company)
            .WithMany(c => c.CompanyPaymentTypes)
            .HasForeignKey(cpt => cpt.CompanyId);
    
        builder
            .HasOne(cpt => cpt.PaymentType)
            .WithMany(pt => pt.CompanyPaymentTypes)
            .HasForeignKey(cpt => cpt.PaymentTypeId);
    
    }
}
