using bizYeriz.Domain.Entities.AuthEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace bizYeriz.Persistence.EntityConfigurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions").HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<SequentialGuidValueGenerator>()
            .HasColumnName("Id")
            .IsRequired();
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
        builder.Property(p => p.Description).HasColumnName("Description").IsRequired(false);
        builder.Property(u => u.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(u => u.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);       
    }
}