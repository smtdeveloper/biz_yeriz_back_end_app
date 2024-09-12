using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace bizYeriz.Persistence.EntityConfigurations;
public class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
{
    public void Configure(EntityTypeBuilder<CompanyUser> builder)
    {
        builder.ToTable("CompanyUsers").HasKey(cu => cu.Id);

        // Sıralı Guid
        builder.Property(f => f.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();

        builder.Property(cu => cu.Id).HasColumnName("Id").IsRequired();
        builder.Property(cu => cu.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(cu => cu.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(cu => cu.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cu => cu.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cu => cu.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cu => !cu.DeletedDate.HasValue);

        builder.HasOne(cu => cu.User);
        builder.HasOne(cu => cu.Company);
    }
}
