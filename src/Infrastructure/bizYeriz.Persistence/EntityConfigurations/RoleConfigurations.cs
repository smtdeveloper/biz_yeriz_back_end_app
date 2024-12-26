using bizYeriz.Domain.Entities.AuthEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace bizYeriz.Persistence.EntityConfigurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<SequentialGuidValueGenerator>()
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(r => r.Name).HasColumnName("Name").IsRequired();
        builder.Property(r => r.Description).HasColumnName("Description").IsRequired(false);
        builder.Property(u => u.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(u => u.IsDelete).HasColumnName("IsDelete").IsRequired();
    }
}