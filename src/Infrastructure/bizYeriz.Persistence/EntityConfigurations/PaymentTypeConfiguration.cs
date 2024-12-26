namespace bizYeriz.Persistence.EntityConfigurations;
using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
{
    public void Configure(EntityTypeBuilder<PaymentType> builder)
    {
        builder.ToTable("PaymentTypes");
        builder.HasKey(pt => pt.Id);
        builder.Property(pt => pt.Name).IsRequired();               
        builder.Property(pt => pt.IsActive).IsRequired();
        builder.Property(pt => pt.IsDelete).IsRequired();
        builder.Property(pt => pt.CreatedDate).IsRequired();
        builder.Property(pt => pt.UpdatedDate).IsRequired(false);
        builder.Property(pt => pt.DeletedDate).IsRequired(false);
    }
}