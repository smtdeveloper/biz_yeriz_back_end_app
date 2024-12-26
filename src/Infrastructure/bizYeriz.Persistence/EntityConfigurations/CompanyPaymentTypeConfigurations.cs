using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class CompanyPaymentTypeConfigurations : IEntityTypeConfiguration<CompanyPaymentType>
{
    public void Configure(EntityTypeBuilder<CompanyPaymentType> builder)
    {
        builder.ToTable("CompanyPaymentTypes");
        builder.HasKey(cpt => new { cpt.CompanyId, cpt.PaymentTypeId });
        builder.Property(cpt => cpt.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(cpt => cpt.IsActive).IsRequired();
        builder.Property(cpt => cpt.IsDelete).IsRequired();
        builder.Property(cpt => cpt.CreatedDate).IsRequired();
        builder.Property(cpt => cpt.UpdatedDate).IsRequired(false);
        builder.Property(cpt => cpt.DeletedDate).IsRequired(false);
      
        builder.HasOne(cpt => cpt.Company)
               .WithMany(c => c.CompanyPaymentTypes)
               .HasForeignKey(cpt => cpt.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cpt => cpt.PaymentType)
               .WithMany(pt => pt.CompanyPaymentTypes)
               .HasForeignKey(cpt => cpt.PaymentTypeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}