using bizYeriz.Domain.Entities.AuthEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("CustomerAddresses").HasKey(ca => ca.Id);       
        builder.Property(ca => ca.Id).HasColumnName("Id").IsRequired();
        builder.Property(ca => ca.UserId).HasColumnName("UserId").IsRequired();
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
    }
}