using bizYeriz.Domain.Entities.CustomerEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {
        builder.ToTable("CustomerAddresses").HasKey(ca => ca.Id);       
        builder.Property(ca => ca.Id).HasColumnName("Id").IsRequired();
        builder.Property(ca => ca.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(ca => ca.CustomerAddressName).HasColumnName("CustomerAddressName").IsRequired();       
        builder.Property(ca => ca.City).HasColumnName("City").IsRequired();
        builder.Property(ca => ca.District).HasColumnName("District").IsRequired();
        builder.Property(ca => ca.Neighbarhood).HasColumnName("Neighbarhood").IsRequired();
        builder.Property(ca => ca.Street).HasColumnName("Street").IsRequired();
        builder.Property(ca => ca.AddreesDetail).HasColumnName("AddreesDetail").IsRequired();
        builder.Property(ca => ca.Lat).HasColumnName("Lat").IsRequired();
        builder.Property(ca => ca.Long).HasColumnName("Long").IsRequired();
        builder.Property(ca => ca.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(ca => ca.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(ca => ca.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ca => ca.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ca => ca.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ca => !ca.DeletedDate.HasValue);
    }
}